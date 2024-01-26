using System;

namespace Cosmos.Gameplay.Providers
{
    public interface IDamageProvider
    {
        public void TakeDamage(int damage = 0);
        public Action<int> OnTakeDamage { get; set; }
    }
}
