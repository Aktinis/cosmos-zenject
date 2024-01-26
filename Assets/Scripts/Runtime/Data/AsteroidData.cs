using System;
using UnityEngine;

namespace Cosmos.Data
{
    [Serializable]
    public sealed class AsteroidData
    {
        [SerializeField] private float initialForce = 10.0f;
        [SerializeField] private string typeId = string.Empty;
        [SerializeField] private int points = 0;
        [SerializeField] private int breakCount = 0;
        [SerializeField] private string breakTypeId = string.Empty;

        public float InitialForce => initialForce;
        public string TypeId => typeId;
        public int Points => points;
        public int BreakCount => breakCount;
        public string BreakTypeId => breakTypeId;
    }
}

