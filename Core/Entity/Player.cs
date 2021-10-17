using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Entity
{
    public class Player : LivingEntity
    {
        public Player(Game1 game) : base(game)
        {
            Position = game.GetCenter();
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
            var kbState = Game.GetKeyboard();

            Speed = kbState.IsKeyDown(Keys.LeftShift) ? 250f : 125f;

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

        public override void Draw(SpriteBatch batch, GameTime time)
        {
            batch.Draw(Sprite, new Vector2(Position.X - Sprite.Width, Position.Y - Sprite.Height), Color.White);
        }
    }
}