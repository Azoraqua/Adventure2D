﻿using Microsoft.Xna.Framework;

namespace Adventure2D.Core.Scenes
{
    public class GameScene : Scene
    {
        public GameScene(Game1 game) : base(game, "Game")
        {
        }
        
        public override void Update()
        {
            // TODO: Implement.
        }

        public override void Draw()
        {
            Game.GraphicsDevice.Clear(Color.Black);
            
            const string text = "Game";
            var (x, y) = Game.GameFont.MeasureString(text);
            
            Game.GraphicsController.DrawText(Game.GameFont, text, new Vector2(Game.GameController.Center.X - x, Game.GameController.Center.Y - y));
        }
    }
}