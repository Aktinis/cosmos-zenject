using Cosmos.Data;
using System;
using UnityEngine;

namespace Cosmos.Gameplay.Settings
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
}

