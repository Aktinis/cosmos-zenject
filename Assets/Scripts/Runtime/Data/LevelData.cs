using System;
using UnityEngine;

namespace Cosmos.Data
{
    [Serializable]
    public sealed class LevelData
    {
        [SerializeField] private string id = string.Empty;
        [SerializeField] private float nextLevelDelay = 2f;
        [SerializeField] private string startAsteroidTypeId = string.Empty;
        [SerializeField] private int startAmount = 4;
        [SerializeField] private int nextLevelMultiplier = 2;

        public float NextLevelDelay => nextLevelDelay;
        public string StartAsteroidTypeId => startAsteroidTypeId;
        public int StartAmount => startAmount;
        public int NextLevelMultiplier => nextLevelMultiplier;
        public string Id => id;
    }
}
