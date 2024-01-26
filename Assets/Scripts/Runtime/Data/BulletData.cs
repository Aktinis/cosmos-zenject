using System;
using UnityEngine;

namespace Cosmos.Data
{
    [Serializable]
    public sealed class BulletData
    {
        [SerializeField] private string id = string.Empty;
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float lifeTime = 0.3f;
        [SerializeField] private float cooldown = 0.3f;

        public string Id => id;
        public float Speed => speed;
        public float LifeTime => lifeTime;
        public float Cooldown => cooldown;
    }
}
