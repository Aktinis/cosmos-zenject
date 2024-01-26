using Cosmos.Components;
using Cosmos.Data;
using Cosmos.Utility;
using System;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    public readonly struct AsteroidSettings
    {
        public AsteroidData Data { get; }
        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
        public Action<int> OnExplode { get; }

        public AsteroidSettings(AsteroidData data, Vector3 position, Vector3 rotation, Action<int> onExplode)
        {
            Data = data;
            Position = position;
            Rotation = rotation;
            OnExplode = onExplode;
        }
    }

    public sealed class Asteroid : MonoBehaviour, IMove, IDamage, IPoolable<AsteroidSettings, IMemoryPool>
    {
        [SerializeField] private Rigidbody2D rigidbody2d;

        private IMemoryPool memoryPool;
        private bool isSpawned = false;
        private AsteroidData data = null;
        private CosmosPoolableComponent modelComponent = null;

        public string TypeId => data.TypeId;
        public Vector3 Position
        {
            get => rigidbody2d.position;
            set => rigidbody2d.MovePosition(value);
        }
        public Action<int> OnTakeDamage { get; set; }

        public void OnDespawned()
        {
            modelComponent.Despawn();
            modelComponent = null;
            isSpawned = false;
            data = null;
            memoryPool = null;
        }
        public void OnSpawned(AsteroidSettings settings, IMemoryPool memoryPool)
        {
            this.data = settings.Data;
            this.memoryPool = memoryPool;
            transform.position = settings.Position;
            transform.eulerAngles = settings.Rotation;
            OnTakeDamage = settings.OnExplode;
            rigidbody2d.AddForce(Quaternion.Euler(settings.Rotation) * Vector3.up * settings.Data.InitialForce);
            isSpawned = true;
        }
        public void AddModel(CosmosPoolableComponent model)
        {
            modelComponent = model;
            model.SetParent(transform);
        }
        public void TakeDamage(int damage = 0)
        {
            if (isSpawned)
            {
                isSpawned = false;
                OnTakeDamage?.Invoke(GetInstanceID());
                memoryPool.Despawn(this);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isSpawned)
            {
                var component = collision.GetComponentInParent<IDamage>();
                if (component != null)
                {
                    component.TakeDamage();
                }
            }
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                TakeDamage();
            }
        }
        public sealed class Factory : PlaceholderFactory<AsteroidSettings, Asteroid>
        {
            private DiContainer container = null;
            public Factory(DiContainer container)
            {
                this.container = container;
            }

            public override Asteroid Create(AsteroidSettings settings)
            {
                var asteroid = base.Create(settings);
                var pool = container.ResolveId<CosmosPoolableComponent.Factory>(settings.Data.TypeId);
                var component = pool.Create();
                asteroid.AddModel(component);
                return asteroid;
            }
        }
        public sealed class Pool : MonoPoolableMemoryPool<AsteroidSettings, IMemoryPool, Asteroid>
        {
        }
    }
}

