using System.Collections.Generic;
using Adventure2D.Core.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Controllers
{
    public sealed class GraphicsController : Controller
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Dictionary<string, Scene> _scenes;

        public Scene CurrentScene { private set; get; }

        public GraphicsController(Game1 game) : base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _scenes = new Dictionary<string, Scene>
            {
                ["Menu"] = new MenuScene(Game),
                ["Game"] = new GameScene(Game)
            };
        }

        public void ChangeScene(string name)
        {
            CurrentScene = _scenes[name];
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
            var (x, y) = position;
            var (tX, tY) = (texture.Width, texture.Height);
            
            _spriteBatch.Draw(texture, new Vector2(x - tX, y - tY), Color.White);
        }

        public void DrawText(SpriteFont font, string text, Vector2 position)
        {
            var (x, y) = position;
            // var (mX, mY) = font.MeasureString(text);
            
            _spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentScene == null)
            {
                CurrentScene = new MenuScene(Game);
            }

            // Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            CurrentScene.Update(gameTime);
            CurrentScene.Draw(_spriteBatch, gameTime);
        }
    }
}