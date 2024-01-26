using Cosmos.Configurations;
using Cosmos.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos.Systems
{
    internal interface IConfigurationSystem
    {
        T GetData<T>(string id);
        T GetDefaultData<T>();
        List<T> GetAllData<T>();

    }

    internal sealed class SimpleConfigurationSystem : IConfigurationSystem
    {
        private readonly Dictionary<Type, string> configurationPathLookUpTable = new Dictionary<Type, string>()
        {
            { typeof(ShipData), "Data/ShipDefaultConfiguration"},
            { typeof(AsteroidData), "Data/AsteroidDefaultConfiguration"},
            { typeof(BulletData), "Data/BulletDefaultConfiguration"},
            { typeof(LevelData), "Data/LevelDefaultConfiguration"},
        };

        private Dictionary<Type, IDataModel> localConfigurationDatabase = new Dictionary<Type, IDataModel>();

        public List<T> GetAllData<T>()
        {
            var type = typeof(T);
            if (!localConfigurationDatabase.ContainsKey(type))
            {
                localConfigurationDatabase.Add(type, (IDataModel)Resources.Load(configurationPathLookUpTable[type]));
            }
            return ((IDataModel<T>)localConfigurationDatabase[type]).GetAllData();
        }

        public T GetData<T>(string id)
        {
            var type = typeof(T);
            if(!localConfigurationDatabase.ContainsKey(type))
            {
                localConfigurationDatabase.Add(type, (IDataModel)Resources.Load(configurationPathLookUpTable[type]));
            }
            return ((IDataModel<T>)localConfigurationDatabase[type]).GetData(id);
        }

        public T GetDefaultData<T>()
        {
            var type = typeof(T);
            if (!localConfigurationDatabase.ContainsKey(type))
            {
                localConfigurationDatabase.Add(type, (IDataModel)Resources.Load(configurationPathLookUpTable[type]));
            }

            return ((IDataModel<T>)localConfigurationDatabase[type]).GetDefault();
        }
    }
}


