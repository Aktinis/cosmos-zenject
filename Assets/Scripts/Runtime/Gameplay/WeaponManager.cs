using Cosmos.Data;
using Cosmos.Gameplay.Settings;
using Cosmos.Systems;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    public sealed class WeaponManager : ITickable
    {
        private readonly Bullet.Factory bulletFactory;
        private readonly BoundsHandler boundsHandler;
        private readonly IConfigurationSystem configurationSystem;
        private List<Bullet> bullets = new List<Bullet>();

        public WeaponManager(Bullet.Factory bulletFactory, IConfigurationSystem configurationSystem, BoundsHandler boundsHandler)
        {
            this.bulletFactory = bulletFactory;
            this.configurationSystem = configurationSystem;
            this.boundsHandler = boundsHandler;
        }

        public void Fire(string id, int senderId, Vector2 startPosition, Quaternion rotation)
        {
            var bulletData = configurationSystem.GetData<BulletData>(id);
            var newBullet = bulletFactory.Create(new BulletSettings(senderId, bulletData, rotation * Vector3.up, startPosition, rotation, Cleanup));
            bullets.Add(newBullet);
        }

        public void Tick()
        {
            if (bullets.Count > 0)
            {
                foreach (var item in bullets)
                {
                    boundsHandler.UpdatePosition(item);
                }
            }
        }
        private void Cleanup(Bullet bullet)
        {
            bullets.Remove(bullet);
        }
    }
}
