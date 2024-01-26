using UnityEngine;

namespace Cosmos.Systems
{
    internal sealed class ResourceSystem : IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object
        {
            return Resources.Load<T>("Models/"+id);
        }
    }
}


