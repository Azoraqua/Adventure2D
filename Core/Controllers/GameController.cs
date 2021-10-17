using Adventure2D.Core.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Controllers
{
    public sealed class GameController : Controller
    {
        public Vector2 Center =>
            new Vector2(
                (float) (Game.Graphics.PreferredBackBufferWidth / 2.0),
                (float) (Game.Graphics.PreferredBackBufferHeight / 2.0)
            );

        private KeyboardState _keyboardState;
        private MouseState _mouseState;

        public GameController(Game1 game) : base(game)
        {
        }

        public KeyboardState GetKeyboard()
        {
            var kbState = Keyboard.GetState();
            _keyboardState = kbState;

            return kbState;
        }

        public MouseState GetMouse()
        {
            var mState = Mouse.GetState();
            _mouseState = mState;

            return mState;
        }

        public override void Update()
        {
            // GetKeyboard();
            // GetMouse();

            if (GetKeyboard().IsKeyDown(Keys.D1) && Game.GraphicsController.CurrentScene.Name != "Menu")
            {
                Game.GraphicsController.ChangeScene("Menu");
            } else if (GetKeyboard().IsKeyDown(Keys.D2) && Game.GraphicsController.CurrentScene.Name != "Game")
            {
                Game.GraphicsController.ChangeScene("Game");
            }
        }
    }
}