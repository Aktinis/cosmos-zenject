using Cosmos.Data;
using UnityEngine;

namespace Cosmos.Gameplay.Settings
{
    internal readonly struct ShipSettings 
    {
        public ShipData Data { get; }
        public Vector3 SpawnPosition { get; }
        public ShipSettings(Vector3 spawnPosition,  ShipData data)
        {
            SpawnPosition = spawnPosition;
            Data = data;
        }
    }
}

