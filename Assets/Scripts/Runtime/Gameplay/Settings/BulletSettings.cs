using Cosmos.Data;
using System;
using UnityEngine;

namespace Cosmos.Gameplay.Settings
{
    internal readonly struct BulletSettings
    {
        public int SenderId { get; }
        public BulletData Data { get; }
        public Vector2 Direction { get; }
        public Vector2 Position { get; }
        public Quaternion Rotation { get; }
        public Action<Bullet> OnExplode { get; }

        public BulletSettings(int senderId, BulletData data, Vector2 direction, Vector2 position, Quaternion rotation, Action<Bullet> onExplode)
        {
            SenderId = senderId;
            Rotation = rotation;
            Position = position;
            Data = data;
            Direction = direction;
            OnExplode = onExplode;
        }
    }
}

