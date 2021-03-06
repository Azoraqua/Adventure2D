using System.Collections.Generic;
using Adventure2D.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Adventure2D.Core.Scenes
{
    public class SettingsScene : Scene
    {
        private readonly List<IComponent> _components = new List<IComponent>();

        public SettingsScene(Game1 game) : base(game, "Settings")
        {
            var sliderTexture = Game.Content.Load<Texture2D>("Components/Slider/Base");
            var sliderLeftTexture = Game.Content.Load<Texture2D>("Components/Slider/ArrowLeft");
            var sliderRightTexture = Game.Content.Load<Texture2D>("Components/Slider/ArrowRight");
            
            _components.Add(new Slider(sliderTexture, sliderLeftTexture, sliderRightTexture, Game.GameFont)
            {
                Position = Game.Center,
                Size = new Vector2(800, 100)
            });
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

            // const string text = "Settings";
            // var (x, y) = Game.GameFont.MeasureString(text);

            // Game.GraphicsController.DrawText(Game.GameFont, text, new Vector2(Game.Center.X - x, Game.Center.Y - y));

            foreach (var component in _components)
            {
                component.Draw(spriteBatch, gameTime);
            }
        }
    }
}