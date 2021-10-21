using Adventure2D.Core.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Controllers
{
    public sealed class GameController : Controller
    {
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

        public override void Update(GameTime gameTime)
        {
            // GetKeyboard();
            // GetMouse();
        }
    }
}