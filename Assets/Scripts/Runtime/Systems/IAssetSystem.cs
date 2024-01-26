using UnityEngine;

namespace Cosmos.Systems
{
    internal interface IAssetSystem
    {
        public T GetAsset<T>(string id) where T : Object;
    }
}


