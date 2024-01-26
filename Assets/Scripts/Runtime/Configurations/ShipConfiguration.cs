using Cosmos.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cosmos.Configurations
{
    [CreateAssetMenu(fileName = nameof(ShipConfiguration) + "_data", menuName = "Data/" + nameof(ShipConfiguration), order = 1)]
    public sealed class ShipConfiguration : ScriptableObject, IDataModel<ShipData>
    {
        [SerializeField] private List<ShipData> ships = new List<ShipData>();

        public List<ShipData> GetAllData() => ships;
        public ShipData GetData(string id) => ships.First(x => x.Id.Equals(id));
        public ShipData GetDefault() => ships.First();
     
    }
}



