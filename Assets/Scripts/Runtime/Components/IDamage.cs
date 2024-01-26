using System;

namespace Cosmos.Components
{
    public interface IDamage
    {
        public void TakeDamage(int damage = 0);
        public Action<int> OnTakeDamage { get; set; }
    }
}
