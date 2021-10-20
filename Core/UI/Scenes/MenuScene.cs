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
        private readonly List<IComponent> _components = new List<IComponent>();

        public MenuScene(Game1 game) : base(game, "Menu")
        {
            var texture = game.Content.Load<Texture2D>("Components/Button");
            var textureFocused = game.Content.Load<Texture2D>("Components/ButtonFocused");

            _components.Add(new Button(texture, textureFocused, game.GameFont)
            {
                Position = new Vector2((float) ((game.Graphics.PreferredBackBufferWidth / 2.0) - (texture.Width / 2.0)),
                    (float) ((game.Graphics.PreferredBackBufferHeight / 2.0) - (texture.Height / 2.0))),
                Size = new Vector2(300, 100),
                Text = "Play",
                TextColor = Color.Black
            });
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