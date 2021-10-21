using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Scenes
{
    public class SettingsScene : Scene
    {
        public SettingsScene(Game1 game) : base(game, "Settings")
        {
        }
        
        public override void Update(GameTime time)
        {
            // TODO: Implement.
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            
            const string text = "Settings";
            var (x, y) = Game.GameFont.MeasureString(text);
            
            Game.GraphicsController.DrawText(Game.GameFont, text, new Vector2(Game.Center.X - x, Game.Center.Y - y));
        }
    }
}