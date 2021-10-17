using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Controller
{
    public sealed class GraphicsController : Controller
    {
        private readonly SpriteBatch _spriteBatch;

        public GraphicsController(Game1 game) : base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public void Begin()
        {
            _spriteBatch.Begin();
        }

        public void End()
        {
            _spriteBatch.End();
        }
        
        public void Draw(Texture2D texture, Vector2 position)
        {
            _spriteBatch.Draw(texture, position, Color.White);
        }

        public void DrawText(SpriteFont font, string text, Vector2 position)
        {
            _spriteBatch.DrawString(font, text, position, Color.White);
        }
        
        public override void Update()
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}