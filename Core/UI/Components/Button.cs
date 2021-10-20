using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Components
{
    public class Button : IComponent
    {
        private readonly Texture2D _texture;
        private readonly SpriteFont _font;

        #region Properties
            public Vector2 Position { get; set; }
            public string Text { get; set; }
        #endregion
        
        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            // Do nothing for now.
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var rect = new Rectangle((int) Position.X, (int) Position.Y, _texture.Width, _texture.Height);
            
            spriteBatch.Draw(_texture, rect, Color.White);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rect.X + (rect.Width / 2) - (_font.MeasureString(Text).X / 2));
                var y = (rect.Y + (rect.Height / 2) - (_font.MeasureString(Text).Y / 2));
                
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), Color.White);
            }
            
            
        }
    }
}