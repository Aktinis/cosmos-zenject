using UnityEngine.SceneManagement;

namespace Cosmos.UI
{
    internal sealed class MenuController : UIController<MenuView>
    {
        protected override void OnStart()
        {
            view.AddStartGameListener(() =>
            {
                SceneManager.LoadScene("Game");
            });
        }
    }
}
