using UnityEngine;

namespace Cosmos.Systems
{
    public interface IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object;
    }

    public sealed class ResourceSystem : IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object
        {
            return Resources.Load<T>("Models/"+id);
        }
    }
}


