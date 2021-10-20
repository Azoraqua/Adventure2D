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

        #region Properties

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public string Text { get; set; }

        public Color TextColor { get; set; }

        public bool IsFocused { get; private set; }

        #endregion

        public Button(Texture2D texture, Texture2D textureFocused, SpriteFont font)
        {
            _texture = texture;
            _textureFocused = textureFocused;
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            var mouse = Mouse.GetState();
            var mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);
            var rect = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y);

            if (mouseRect.Intersects(rect))
                IsFocused = true;
            else
                IsFocused = false;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var rect = new Rectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y);

            if (IsFocused)
            {
                spriteBatch.Draw(_textureFocused, rect, Color.White);
            }
            else
            {
                spriteBatch.Draw(_texture, rect, Color.White);
            }

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rect.X + (rect.Width / 2) - (_font.MeasureString(Text).X / 2));
                var y = (rect.Y + (rect.Height / 2) - (_font.MeasureString(Text).Y / 2));

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), TextColor);
            }
        }
    }
}