using Cosmos.Components;
using Cosmos.Data;
using Cosmos.Systems;
using System;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    public readonly struct ShipSettings 
    {
        public ShipData Data { get; }
        public Vector3 SpawnPosition { get; }
        public ShipSettings(Vector3 spawnPosition,  ShipData data)
        {
            SpawnPosition = spawnPosition;
            Data = data;
        }
    }

    public sealed class Ship : MonoBehaviour, IPawn, IHealth, IDamage
    {
        [SerializeField] private Rigidbody2D rigidbody2d;

        private int direction = 0;
        private bool useThrust = false;
        private ShipData data = null;
        private int health = 10;
        private Collider2D collider2d = null;

        public Vector3 Position 
        { 
            get => rigidbody2d.position; 
            set => rigidbody2d.MovePosition(value); 
        }
        public Action<int> OnTakeDamage { get; set; } = null;
        public bool IsAlive => health > 0;
        public int Health => health;

        public Quaternion Rotation 
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        [Inject]
        public void Construct(ShipSettings settings)
        {
            health = settings.Data.Health;
            data = settings.Data;
            transform.position = settings.SpawnPosition;
        }

        private void FixedUpdate()
        {
            if (useThrust)
            {
                rigidbody2d.AddForce(transform.up * data.Speed);
            }

            if (direction != 0)
            {
                rigidbody2d.SetRotation(rigidbody2d.rotation + direction * data.RotationSpeed * Time.fixedDeltaTime);
            }
        }

        public void Rotate(int direction)
        {
            this.direction = direction;
        }

        public void Thrust(bool useThrust)
        {
            this.useThrust = useThrust;
        }

        public void TakeDamage(int damage)
        {
            health--;
            OnTakeDamage?.Invoke(GetInstanceID());
            if (health <= 0)
            {
                gameObject.SetActive(false);
                OnTakeDamage = null;
            }

        }

        public void ToggleCollision(bool state)
        {
            if (collider2d == null)
            {
                collider2d = GetComponentInChildren<Collider2D>();
            }
            collider2d.enabled = !state;
        }

        public sealed class Factory : PlaceholderFactory<ShipSettings, Ship>
        {
            private readonly IAssetSystem assetSystem;
            [Inject]
            public Factory(IAssetSystem assetSystem)
            {
                this.assetSystem = assetSystem;
            }

            public override Ship Create(ShipSettings settings)
            {
                var ship = base.Create(settings);
                Instantiate(assetSystem.GetAsset<Transform>(settings.Data.Id), ship.transform);
                return ship;
            }
        }
    }
}

