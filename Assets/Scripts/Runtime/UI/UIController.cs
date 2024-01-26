using UnityEngine;

namespace Cosmos.UI
{
    public abstract class UIController<TView> : MonoBehaviour where TView : View 
    {
        protected TView view;
        protected virtual void Awake()
        {
            view = GetComponent<TView>();
        }

        protected void Start()
        {
            OnStart();
            view.Initialize();
        }

        protected virtual void OnStart() { }
    }
}
