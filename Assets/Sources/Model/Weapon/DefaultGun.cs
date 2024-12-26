using System;

namespace Asteroids.Model
{
    public class DefaultGun
    {
        public event Action<Bullet> Slot;

        public virtual bool CanShoot() => true;

        public void Shoot()
        {
            if (CanShoot() == false)
                throw new InvalidOperationException();
        }

        protected virtual Bullet GetBullet() => new DefaultBullet();
    }
}
