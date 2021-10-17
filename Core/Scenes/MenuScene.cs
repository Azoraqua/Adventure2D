using Microsoft.Xna.Framework;

namespace Adventure2D.Core.Scenes
{
    public class MenuScene : Scene
    {
        public MenuScene(Game1 game) : base(game, "Menu")
        {
        }
        
        public override void Update()
        {
            // TODO: Implement.
        }

        public override void Draw()
        {
            Game.GraphicsDevice.Clear(Color.Black);
            
            const string text = "Menu";
            var (x, y) = Game.GameFont.MeasureString(text);
            
            Game.GraphicsController.DrawText(Game.GameFont, text, new Vector2(Game.GameController.Center.X - x, Game.GameController.Center.Y - y));
        }
    }
}