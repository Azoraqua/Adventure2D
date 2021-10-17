using Adventure2D.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventure2D
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        // private Camera _camera;

        private SpriteFont _gameFont;
        private Player _player;

        private KeyboardState _keyboardState;
        private MouseState _mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            _player = new Player(this);
            // _camera = new Camera(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameFont = Content.Load<SpriteFont>("Fonts/Game");
            _player.LoadContent();
            // _camera.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var dt = (float) gameTime.ElapsedGameTime.TotalSeconds;
            var kbState = Keyboard.GetState();

            // TODO: Handle key-presses.

            _player.Update(gameTime);

            // _camera.Update(gameTime);
            _keyboardState = kbState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // _spriteBatch.Begin(_camera);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_gameFont,
                $"FPS: {(1 / gameTime.ElapsedGameTime.TotalSeconds).ToString().Substring(0, 5)}", new Vector2(3, 3),
                Color.White);
            _player.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public KeyboardState GetKeyboard()
        {
            var kbState = Keyboard.GetState();
            _keyboardState = kbState;

            return kbState;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(
                (float) (_graphics.PreferredBackBufferWidth / 2.0),
                (float) (_graphics.PreferredBackBufferHeight / 2.0)
            );
        }
    }
}