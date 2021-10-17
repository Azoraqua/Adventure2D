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
            _spriteBatch.Draw(texture, position, Color.White);
        }

        public void DrawText(SpriteFont font, string text, Vector2 position)
        {
            _spriteBatch.DrawString(font, text, position, Color.White);
        }

        public override void Update()
        {
            if (CurrentScene == null)
            {
                CurrentScene = new MenuScene(Game);
            }

            // Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            CurrentScene.Draw();
        }
    }
}