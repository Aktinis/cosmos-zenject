using UnityEngine.SceneManagement;

namespace Cosmos.Systems
{
    internal interface ISceneManagingSystem 
    {
        public void LoadSceneAsync(string name, bool loadAdditionalAssets = false);
    }

    internal sealed class CosmosSceneManagingSystem : ISceneManagingSystem
    {
        private readonly IAssetSystem assetSystem;
        public CosmosSceneManagingSystem(IAssetSystem assetSystem)
        {
            this.assetSystem = assetSystem;
        }

        public async void LoadSceneAsync(string name, bool loadAdditionalAssets = false)
        {
            assetSystem.UnloadAssets();
            if(loadAdditionalAssets)
            {
                await assetSystem.AsyncLoadAssets();
            }
            SceneManager.LoadSceneAsync(name);
        }
    }
}