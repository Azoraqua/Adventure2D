using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Scenes
{
    public class GameScene : Scene
    {
        public GameScene(Game1 game) : base(game, "Game")
        {
        }
        
        public override void Update(GameTime time)
        {
           
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            
            const string text = "Game";
            var (x, y) = Game.GameFont.MeasureString(text);
            
            Game.GraphicsController.DrawText(Game.GameFont, text, new Vector2(Game.Center.X - x, Game.Center.Y - y));
        }
    }
}