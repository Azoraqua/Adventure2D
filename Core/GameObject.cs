using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core
{
    public abstract class GameObject
    {
        protected readonly Game1 Game;

        protected GameObject(Game1 game)
        {
            Game = game;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime time);

        public abstract void Draw(GameTime time);
    }
}