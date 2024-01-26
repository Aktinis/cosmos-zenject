using Cosmos.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cosmos.Configurations
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfiguration) + "_data", menuName = "Data/" + nameof(AsteroidConfiguration), order = 1)]
    public sealed class AsteroidConfiguration : ScriptableObject, IDataModel<AsteroidData>
    {
        [SerializeField] private List<AsteroidData> asteroids = new List<AsteroidData>();

        public List<AsteroidData> GetAllData() => asteroids;
        public AsteroidData GetData(string id) => asteroids.First(x => x.TypeId.Equals(id));
        public AsteroidData GetDefault() => asteroids.First();
    }
}

