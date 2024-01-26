using UnityEngine;

namespace Cosmos.Systems
{
    internal interface IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object;
    }

    internal sealed class ResourceSystem : IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object
        {
            return Resources.Load<T>("Models/"+id);
        }
    }
}


