using System;
using System.Collections.Generic;
using System.Runtime.Loader;
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
            var textureHovered = game.Content.Load<Texture2D>("Components/ButtonHovered");

            var button = new Button(texture, textureHovered, game.GameFont)
            {
                Position = new Vector2(Game.Center.X, Game.Center.Y - 100),
                Size = new Vector2(300, 100),
                Text = "Play",
                TextColor = Color.Black
            };
            button.Click += (sender, args) => game.GraphicsController.ChangeScene("Game");
            _components.Add(button);

            button = new Button(texture, textureHovered, game.GameFont)
            {
                Position = new Vector2(Game.Center.X, Game.Center.Y),
                Size = new Vector2(300, 100),
                Text = "Settings",
                TextColor = Color.Black
            };
            button.Click += (sender, args) => game.GraphicsController.ChangeScene("Settings");
            _components.Add(button);
            
            button = new Button(texture, textureHovered, game.GameFont)
            {
                Position = new Vector2(Game.Center.X, Game.Center.Y + 100),
                Size = new Vector2(300, 100),
                Text = "Exit",
                TextColor = Color.Black
            };
            button.Click += (sender, args) => Environment.Exit(0);
            _components.Add(button);
        }

        public override void Update(GameTime time)
        {
            foreach (var component in _components)
            {
                component.Update(time);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            Game.IsMouseVisible = true;

            foreach (var component in _components)
            {
                component.Draw(spriteBatch, gameTime);
            }
        }
    }
}