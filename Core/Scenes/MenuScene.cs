using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Scenes
{
    public class MenuScene : Scene
    {
        public MenuScene(Game1 game) : base(game, "Menu")
        {
        }

        public override void Update()
        {
            var mouse = Game.GameController.GetMouse();
            var (x, y) = mouse.Position;

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (x == 2)
                {
                }
            }
        }

        public override void Draw()
        {
            Game.GraphicsDevice.Clear(Color.Black);
            Game.IsMouseVisible = true;

            var text = "Play";
            var m = Game.GameFont.MeasureString(text);

            Game.GraphicsController.DrawText(
                Game.GameFont,
                text,
                new Vector2(Game.GameController.Center.X - m.X, Game.GameController.Center.Y - m.Y - 100)
            );

            text = "Settings";
            m = Game.GameFont.MeasureString(text);

            Game.GraphicsController.DrawText(
                Game.GameFont,
                text,
                new Vector2((float) (Game.GameController.Center.X - (m.Length() / 1.5)),
                    Game.GameController.Center.Y - m.Y)
            );

            text = "Exit";
            m = Game.GameFont.MeasureString(text);

            Game.GraphicsController.DrawText(
                Game.GameFont,
                text,
                new Vector2(Game.GameController.Center.X - m.X, Game.GameController.Center.Y - m.Y + 100)
            );
        }
    }
}