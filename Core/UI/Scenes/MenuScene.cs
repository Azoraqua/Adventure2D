using System;
using System.Collections.Generic;
using Adventure2D.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D.Core.Scenes
{
    public class MenuScene : Scene
    {
        private readonly List<IComponent> _components = new List<IComponent>
        {
            Capacity = 0
        };

        public MenuScene(Game1 game) : base(game, "Menu")
        {
        }

        public override void Update(GameTime time)
        {
            _components.ForEach(c => c.Update(time));
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            Game.IsMouseVisible = true;

            _components.ForEach(c => c.Draw(spriteBatch, gameTime));
        }
    }
}