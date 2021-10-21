using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Components
{
    public class Button : IComponent
    {
        private readonly Texture2D _texture;
        private readonly Texture2D _textureHovered;
        private readonly SpriteFont _font;

        #region Internals

        private MouseState _prevMouseState;
        private MouseState _currentMouseState;

        #endregion

        #region Properties

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public string Text { get; set; }

        public Color TextColor { get; set; }

        public event EventHandler Hover;

        public bool IsHovered { get; private set; }

        public event EventHandler Click;

        public bool IsClicked { get; private set; }

        #endregion

        public Button(Texture2D texture, Texture2D textureHovered, SpriteFont font)
        {
            _texture = texture;
            _textureHovered = textureHovered;
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            _prevMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
            var rect = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y);

            IsHovered = false;
            IsClicked = false;

            if (mouseRect.Intersects(rect))
            {
                IsHovered = true;
                // Hover?.Invoke(this, EventArgs.Empty);

                if (_currentMouseState.LeftButton == ButtonState.Released &&
                    _prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    IsClicked = true;
                    Click?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var (sizeX, sizeY) = Size;
            var (posX, posY) = Position;

            // Fix for misalignment when positioning.
            posX -= sizeX / 2.0f;
            posY -= sizeY / 2.0f;

            var rect = new Rectangle((int) posX, (int) posY, (int) sizeX, (int) sizeY);

            spriteBatch.Draw(
                IsHovered ? _textureHovered : _texture,
                rect,
                Color.White
            );

            var textX = (rect.X + (rect.Width / 2) - (_font.MeasureString(Text).X / 2));
            var textY = (rect.Y + (rect.Height / 2) - (_font.MeasureString(Text).Y / 2));

            if (!string.IsNullOrEmpty(Text))
            {
                spriteBatch.DrawString(_font, Text, new Vector2(textX, textY), TextColor);
            }
        }
    }
}