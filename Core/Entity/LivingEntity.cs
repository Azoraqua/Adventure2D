namespace Adventure2D.Entity
{
    public abstract class LivingEntity : Entity
    {
        protected float Speed;
        protected float Health;

        protected LivingEntity(Game1 game) : base(game) { }
    }
}