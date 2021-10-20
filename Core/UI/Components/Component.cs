using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Components
{
    public interface IComponent
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}