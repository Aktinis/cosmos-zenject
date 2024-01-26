using Cosmos.Gameplay.Providers;
using UnityEngine;
using Zenject;

namespace Cosmos.Gameplay
{
    internal sealed class InvincibilityHandler : ITickable
    {
        private const float INVINCIBILITY_TIMER = 3f;
        public float startTime = 0f;
        public IInvincibilityProvider invincibility = null;
        private bool hasInstance = false;

        public InvincibilityHandler() { }

        public void UpdateInvincibility(IInvincibilityProvider invincibility)
        {
            if(hasInstance == false)
            {
                hasInstance = true;
                this.invincibility = invincibility;
                startTime = Time.realtimeSinceStartup;
                invincibility.ToggleInvincibility(true);
            }
        }

        public void Tick()
        {
            if (hasInstance && Time.realtimeSinceStartup - startTime > INVINCIBILITY_TIMER)
            {
                invincibility.ToggleInvincibility(false);
                invincibility = null;
                hasInstance = false;
            }
        }
    }
}
