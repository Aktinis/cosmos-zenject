using UnityEngine;

namespace Cosmos.Gameplay.Providers
{
    internal interface IRotationProvider
    {
        public Quaternion Rotation { get; set; }
    }
}
