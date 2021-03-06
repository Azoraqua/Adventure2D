using Microsoft.Xna.Framework;

namespace Adventure2D.Core.Controllers
{
    public abstract class Controller
    {
        protected readonly Game1 Game;

        protected Controller(Game1 game)
        {
            Game = game;
        }

        public abstract void Update(GameTime gameTime);
    }
}