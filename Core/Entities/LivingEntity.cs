namespace Adventure2D.Core.Entities
{
    public abstract class LivingEntity : Entity
    {
        protected float Speed;
        protected float Health;

        protected LivingEntity(Game1 game) : base(game) { }
    }
}