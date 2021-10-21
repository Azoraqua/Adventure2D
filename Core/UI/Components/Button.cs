using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Components
{
    public class Button : IComponent
    {
        private readonly Texture2D _texture;
        private readonly Texture2D _textureFocused;
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

        public bool IsFocused { get; private set; }

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        #endregion

        public Button(Texture2D texture, Texture2D textureFocused, SpriteFont font)
        {
            _texture = texture;
            _textureFocused = textureFocused;
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            _prevMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRect = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
            var rect = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y);

            IsFocused = false;

            if (mouseRect.Intersects(rect))
            {
                IsFocused = true;

                if (_currentMouseState.LeftButton == ButtonState.Released &&
                    _prevMouseState.LeftButton == ButtonState.Pressed)
                {
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
                IsFocused ? _textureFocused : _texture,
                rect,
                Color.White
            );

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rect.X + (rect.Width / 2) - (_font.MeasureString(Text).X / 2));
                var y = (rect.Y + (rect.Height / 2) - (_font.MeasureString(Text).Y / 2));
            
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), TextColor);
            }
        }
    }
}