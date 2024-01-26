using Cosmos.Data;
using Cosmos.Systems;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    internal sealed class LevelManager : ITickable
    {
        private readonly AsteroidManager asteroidManager = null;
        private readonly LevelData levelData = null;
        private readonly LevelBounds levelBounds = null;

        private int levelCount = 0;
        private bool isReady = false;
        private float delayStartTime = 0.0f;

        public LevelManager(AsteroidManager asteroidManager, IConfigurationSystem configurationSystem, LevelBounds levelBounds)
        {
            this.levelBounds = levelBounds;
            this.asteroidManager = asteroidManager;
            levelData = configurationSystem.GetDefaultData<LevelData>();
        }
        public void Start()
        {
            var count = levelData.StartAmount + levelCount * levelData.NextLevelMultiplier;
            for (int i = 0; i < count; i++)
            {
                asteroidManager.SpawnAsteroid(levelBounds.GetRandomisedBoundPosition(), levelData.StartAsteroidTypeId);
            }

            isReady = true;
        }
        public void End()
        {
            isReady = false;
        }
        public void Tick()
        {
            if (isReady == false) return;
            if (asteroidManager.HasAliveAsteroids == false)
            {
                if (levelData.NextLevelDelay < delayStartTime)
                {
                    levelCount++;
                    Start();
                    delayStartTime = 0.0f;
                }
                delayStartTime += Time.deltaTime;
            }
        }
    }
}
