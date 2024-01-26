using System.Collections.Generic;

namespace Cosmos.Systems
{
    internal interface IConfigurationSystem
    {
        T GetData<T>(string id);
        T GetDefaultData<T>();
        List<T> GetAllData<T>();

    }
}


