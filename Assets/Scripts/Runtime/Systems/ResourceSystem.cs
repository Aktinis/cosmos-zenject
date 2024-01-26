using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cosmos.Systems
{
    internal sealed class AddressableAssetManager : IAssetSystem
    {
        private readonly Dictionary<string, GameObject> assetReferences = new Dictionary<string, GameObject>();

        private AsyncOperationHandle lastLoadedOperationHandle;

        public T GetAsset<T>(string name) where T : Object
        {
            return assetReferences[name].GetComponent<T>();
        }

        private Task AsyncLoadAssets(List<string> labels)
        {
            lastLoadedOperationHandle = Addressables.LoadAssetsAsync<GameObject>(labels, (obj) =>
            {
                assetReferences.Add(obj.name, obj);
            }, Addressables.MergeMode.Union,
            false);
            return lastLoadedOperationHandle.Task;
        }

        public Task AsyncLoadAssets()
        {
            return AsyncLoadAssets(new List<string>(){ "ship", "asteroid" });
        }

        public void UnloadAssets()
        {
            if(assetReferences.Count > 0)
            {
                assetReferences.Clear();
                Addressables.Release(lastLoadedOperationHandle);
            }
        }
    }

}


