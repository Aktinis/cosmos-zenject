using System.Collections.Generic;

namespace Cosmos.Configurations
{
    public interface IDataModel { }

    public interface IDataModel<T> : IDataModel
    {
        T GetDefault();
        T GetData(string id);
        List<T> GetAllData();
    }
}


