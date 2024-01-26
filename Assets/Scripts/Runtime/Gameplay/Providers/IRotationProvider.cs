using UnityEngine;

namespace Cosmos.Gameplay.Providers
{
    public interface IRotationProvider
    {
        public Quaternion Rotation { get; set; }
    }
}
