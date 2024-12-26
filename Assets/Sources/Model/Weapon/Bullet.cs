namespace Asteroids.Model
{
    public abstract class Bullet
    {
        public readonly float LifeTime;
        public readonly float Speed;

        protected Bullet(float lifeTime, float speed)
        {
            LifeTime = lifeTime;
            Speed = speed;
        }
    }

    public class LaserGunBullet : Bullet
    {
        public LaserGunBullet() : base(0.5f, 0f) { }                    // Magic
    }

    public class DefaultBullet : Bullet
    {
        public DefaultBullet() : base(10f, 0.6f) { }                    // Magic
    }
}
