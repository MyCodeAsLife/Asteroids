namespace Asteroids.Model
{
    public class LaserGunRollback
    {
        private LaserGun _laser;
        private float _cooldown;

        public float AccumulatedTime { get; private set; }

        public LaserGunRollback(LaserGun laser, float cooldown)
        {
            _laser = laser;
            _cooldown = cooldown;
        }

        public void Tick(float deltaTime)
        {
            if (_laser.Bullets == _laser.MaxBullets)
                return;

            AccumulatedTime += deltaTime;

            if (AccumulatedTime >= _cooldown)
            {
                _laser.TryAddShot();
                AccumulatedTime = 0f;
            }
        }
    }
}
