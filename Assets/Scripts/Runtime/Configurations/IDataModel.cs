using System.Collections.Generic;

namespace Cosmos.Configurations
{
    internal interface IDataModel { }

    internal interface IDataModel<T> : IDataModel
    {
        T GetDefault();
        T GetData(string id);
        List<T> GetAllData();
    }
}


