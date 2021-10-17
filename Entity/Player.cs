using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Entity
{
    public class Player : Entity
    {
        public Player(Game1 game) : base(game)
        {
            Position = game.GetCenter();
            Direction = Direction.Down;
        }

        public override void LoadContent()
        {
            Sprite = Game.Content.Load<Texture2D>("Textures/Entity/Player");
        }

        public override void Update(GameTime time)
        {
            var speed = 100;
            var dt = (float) time.ElapsedGameTime.TotalSeconds;
            var kbState = Game.GetKeyboard();
            
            if (kbState.IsKeyDown(Keys.W))
            {
                Position.Y -= (speed * dt);
                Direction = Direction.Up;
            }
            
            if (kbState.IsKeyDown(Keys.S))
            {
                Position.Y += (speed * dt);
                Direction = Direction.Down;
            }
            
            if (kbState.IsKeyDown(Keys.A))
            {
                Position.X -= (speed * dt);
                Direction = Direction.Left;
            }
            
            if (kbState.IsKeyDown(Keys.D))
            {
                Position.X += (speed * dt);
                Direction = Direction.Right;
            }
        }

        public override void Draw(SpriteBatch batch, GameTime time)
        {
            batch.Draw(Sprite, new Vector2(Position.X - Sprite.Width, Position.Y - Sprite.Height), Color.White);
        }
    }
}