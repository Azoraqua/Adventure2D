using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Components
{
    public class Slider : IComponent
    {
        private readonly Texture2D _textureLeft;
        private readonly Texture2D _textureRight;
        private readonly Texture2D _textureSlider;
        private readonly SpriteFont _font;

        #region Properties
            public Vector2 Position { get; set; }
            public Vector2 Size { get; set; }

            public event EventHandler OnPrevious;
            public event EventHandler OnNext;

            public (int, string) Previous { get; private set; }
            public (int, string) Next { get; private set; }
        #endregion
        
        public Slider(Texture2D textureSlider, Texture2D textureLeft, Texture2D textureRight, SpriteFont font)
        {
            _textureSlider = textureSlider;
            _textureLeft = textureLeft;
            _textureRight = textureRight;
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            // Do something.
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var (sizeX, sizeY) = Size;
            var (posX, posY) = Position;
            
            posX -= sizeX / 2.0f;
            posY -= sizeY / 2.0f;
            
            var rect = new Rectangle((int) posX, (int) posY, (int) sizeX, (int) sizeY);
            
            spriteBatch.Draw(
                _textureSlider,
                rect,
                Color.White
            );
        }
    }
}