namespace Adventure2D.Core.Scenes
{
    public abstract class Scene
    {
        protected readonly Game1 Game;

        public string Name
        {
            get;
            private set;
        }
        
        protected Scene(Game1 game, string name)
        {
            Game = game;
            Name = name;
        }

        public abstract void Update();
        
        public abstract void Draw();
    }
}