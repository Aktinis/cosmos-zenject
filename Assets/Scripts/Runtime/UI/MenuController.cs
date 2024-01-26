using Cosmos.Systems;
using Zenject;

namespace Cosmos.UI
{
    internal sealed class MenuController : UIController<MenuView>
    {
        private ISceneManagingSystem sceneManagingSystem;

        [Inject]
        public void Construct(ISceneManagingSystem sceneManagingSystem)
        {
            this.sceneManagingSystem = sceneManagingSystem;
        }

        protected override void OnStart()
        {
            view.AddStartGameListener(() =>
            {
                sceneManagingSystem.LoadSceneAsync("Game", true);
            });
        }
    }
}
