using Adventure2D.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Entity
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public abstract class Entity : GameObject
    {
        protected Vector2 Position;
        protected Direction Direction;
        protected Texture2D Sprite;

        protected Entity(Game1 game) : base(game)
        {
        }
    }
}