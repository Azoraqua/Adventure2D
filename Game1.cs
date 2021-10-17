﻿using System.Reflection;
using Adventure2D.Core.Controller;
using Adventure2D.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D
{
    public class Game1 : Game
    {
        /*
         * TODO:
         *  - Fix startup crash, -532,462,766
         */
        
        public readonly GraphicsDeviceManager Graphics;
        public GraphicsController GraphicsController;
        public GameController GameController;
        
        // private Camera _camera;

        public SpriteFont GameFont
        {
            get;
            private set;
        }

        public Player Player
        {
            get;
            private set;
        }
        

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            GameController = new GameController(this);
            GraphicsController = new GraphicsController(this);

            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();

            Player = new Player(this);
            // _camera = new Camera(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GameFont = Content.Load<SpriteFont>("Fonts/Game");
            Player.LoadContent();
            // _camera.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameController.GetKeyboard().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Handle generic key-presses.

            GameController.Update();
            Player.Update(gameTime);
            // _camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // _spriteBatch.Begin(_camera);
            GraphicsController.Begin();
            GraphicsController.Update();
            Player.Draw(gameTime);
            GraphicsController.End();
            
            base.Draw(gameTime);
        }
    }
}