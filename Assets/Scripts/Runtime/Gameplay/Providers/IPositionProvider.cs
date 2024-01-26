using UnityEngine;

namespace Cosmos.Gameplay.Providers
{
    internal interface IPositionProvider
    {
        public Vector3 Position { get; set; }
    }
}
