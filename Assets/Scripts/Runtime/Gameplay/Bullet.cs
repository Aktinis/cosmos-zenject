using Cosmos.Data;
using Cosmos.Gameplay.Providers;
using Cosmos.Gameplay.Settings;
using System;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    public sealed class Bullet : MonoBehaviour, IPositionProvider, IPoolable<BulletSettings, IMemoryPool>
    {
        private IMemoryPool memoryPool;
        private BulletData data = null;
        private int senderId = -1;
        private float startTime = 0;
        private Action<Bullet> onExplode;
        private bool isSpawned = false;


        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void OnDespawned()
        {
            memoryPool = null;
            isSpawned = false;
        }

        public void OnSpawned(BulletSettings settings, IMemoryPool memoryPool)
        {
            data = settings.Data;
            this.onExplode = settings.OnExplode;
            this.memoryPool = memoryPool;
            startTime = Time.realtimeSinceStartup;
            transform.rotation = settings.Rotation;
            transform.position = settings.Position + settings.Direction;
            senderId = settings.SenderId;
            isSpawned = true;
        }

        private void Update()
        {
            if(isSpawned)
            {
                transform.position += transform.up * data.Speed * Time.deltaTime;
                if (Time.realtimeSinceStartup - startTime > data.LifeTime)
                {
                    onExplode.Invoke(this);
                    memoryPool.Despawn(this);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isSpawned && collision.transform.root.gameObject.GetInstanceID() != senderId)
            {
                var component = collision.GetComponentInParent<IDamageProvider>();
                if(component != null)
                {
                    component.TakeDamage();
                    onExplode.Invoke(this);
                    memoryPool.Despawn(this);
                    isSpawned = false;
                }

            }
        }

        public class Factory : PlaceholderFactory<BulletSettings, Bullet>
        {
        }

        public class Pool : MonoPoolableMemoryPool<BulletSettings, IMemoryPool, Bullet>
        {
        }
    }
}

