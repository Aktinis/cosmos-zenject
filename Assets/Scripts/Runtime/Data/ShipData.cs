using System;
using UnityEngine;

namespace Cosmos.Data
{
    [Serializable]
    internal sealed class ShipData
    {
        [SerializeField] private string id = string.Empty;
        [SerializeField] private string weaponId = string.Empty;
        [SerializeField] private float rotationSpeed = 180.0f;
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float fireCooldown = 0.5f;
        [SerializeField] private int health = 0;

        public string Id => id;
        public float Speed => speed;
        public float FireCooldown => fireCooldown;
        public float RotationSpeed => rotationSpeed;
        public string WeaponId => weaponId;
        public int Health => health;
    }
}



