using UnityEngine;

namespace Cosmos.Gameplay.Providers
{
    public interface IPositionProvider
    {
        public Vector3 Position { get; set; }
    }
}
