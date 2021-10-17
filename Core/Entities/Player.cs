using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Entities
{
    public class Player : LivingEntity
    {
        public Player(Game1 game) : base(game)
        {
            Position = game.GameController.Center;
            Direction = Direction.Down;
            Speed = 125f;
            Health = 100f;
        }

        public override void LoadContent()
        {
            Sprite = Game.Content.Load<Texture2D>("Textures/Entity/Player");
        }

        public override void Update(GameTime time)
        {
            var dt = (float) time.ElapsedGameTime.TotalSeconds;
            var kbState = Game.GameController.GetKeyboard();

            if (kbState.IsKeyDown(Keys.W))
            {
                Position.Y -= (Speed * dt);
                Direction = Direction.Up;
            }

            if (kbState.IsKeyDown(Keys.S))
            {
                Position.Y += (Speed * dt);
                Direction = Direction.Down;
            }

            if (kbState.IsKeyDown(Keys.A))
            {
                Position.X -= (Speed * dt);
                Direction = Direction.Left;
            }

            if (kbState.IsKeyDown(Keys.D))
            {
                Position.X += (Speed * dt);
                Direction = Direction.Right;
            }
        }

        public override void Draw(GameTime time)
        {
            Game.GraphicsController.Draw(Sprite, Vector2.Subtract(Position, new Vector2(Sprite.Width, Sprite.Height)));
        }
    }
}