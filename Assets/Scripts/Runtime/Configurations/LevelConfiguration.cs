using Cosmos.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cosmos.Configurations
{
    [CreateAssetMenu(fileName = nameof(LevelConfiguration)+ "_data", menuName = "Data/"+ nameof(LevelConfiguration), order = 1)]
    public sealed class LevelConfiguration : ScriptableObject, IDataModel<LevelData>
    {
        [SerializeField] private List<LevelData> levels = new List<LevelData>();

        public List<LevelData> GetAllData() => levels;
        public LevelData GetData(string id) => levels.First(x => x.Id.Equals(id));
        public LevelData GetDefault() => levels.First();
    }
}
