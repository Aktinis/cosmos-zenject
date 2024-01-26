using UnityEngine.SceneManagement;

namespace Cosmos.UI
{
    public sealed class MenuController : UIController<MenuView>
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
