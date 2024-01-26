using Cosmos.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cosmos.Configurations
{
    [CreateAssetMenu(fileName = nameof(BulletConfiguration) + "_data", menuName = "Data/" + nameof(BulletConfiguration), order = 1)]
    internal sealed class BulletConfiguration : ScriptableObject, IDataModel<BulletData>
    {
        [SerializeField] private List<BulletData> bullets = new List<BulletData>();

        public List<BulletData> GetAllData() => bullets;
        public BulletData GetData(string id) => bullets.First(x => x.Id.Equals(id));
        public BulletData GetDefault() => bullets.First();
    }
}
