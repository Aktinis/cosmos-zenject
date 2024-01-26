using UnityEngine;
using Zenject;

namespace Cosmos.Utility
{
    public class CosmosPoolableComponent : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private IMemoryPool memoryPool = null;

        public void Despawn()
        {
            memoryPool.Despawn(this);
        }
        public void OnDespawned()
        {
            transform.SetParent(null);
            memoryPool = null;
        }
        public void OnSpawned(IMemoryPool memoryPool)
        {
            this.memoryPool = memoryPool;
        }
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }

        public sealed class Pool : MonoPoolableMemoryPool<IMemoryPool, CosmosPoolableComponent> { }
        public sealed class Factory : PlaceholderFactory<CosmosPoolableComponent> { }
    }
}

