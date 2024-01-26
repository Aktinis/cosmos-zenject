using Cosmos.Data;
using Cosmos.Gameplay.Settings;
using Cosmos.Systems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    public sealed class AsteroidManager : ITickable
    {
        private readonly Asteroid.Factory factory = null;
        private readonly BoundsHandler boundsHandler = null;
        private readonly IConfigurationSystem configurationSystem = null;
        private readonly IScoreSystem scoreSystem = null;
        private readonly List<Asteroid> asteroids = new List<Asteroid>();

        public bool HasAliveAsteroids => asteroids.Count > 0;

        public AsteroidManager(Asteroid.Factory factory, BoundsHandler boundsHandler, IConfigurationSystem configurationSystem, IScoreSystem scoreSystem)
        {
            this.scoreSystem = scoreSystem;
            this.configurationSystem = configurationSystem;
            this.factory = factory;
            this.boundsHandler = boundsHandler;
        }

        private void Remove(int instanceId)
        {
            var asteroid = asteroids.First(x=> x.GetInstanceID() == instanceId);
            scoreSystem.UpdateScore(asteroid.TypeId);
            BreakAsteroid(asteroid.Position, asteroid.TypeId);
            asteroids.Remove(asteroid);
        }

        public void SpawnAsteroid(Vector3 position, string typeId)
        {
            var data = configurationSystem.GetData<AsteroidData>(typeId);
            var settings = new AsteroidSettings(data, position, new Vector3(0, 0, Random.Range(0, 360)), Remove);
            asteroids.Add(factory.Create(settings));
        }

        public void Tick()
        {
            if (asteroids.Count > 0)
            {
                foreach (var item in asteroids)
                {
                    boundsHandler.UpdatePosition(item);
                }
            }
        }

        private void BreakAsteroid(Vector3 position, string typeId)
        {
            var data = configurationSystem.GetData<AsteroidData>(typeId);
            for (int i = 0; i < data.BreakCount; i++)
            {
                SpawnAsteroid(position, data.BreakTypeId);
            }
        }
    }
}

