using UnityEngine;

namespace Cosmos.Gameplay
{
    internal class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        public float AspectRatio => cam.aspect;
        public float OrthographicSize => cam.orthographicSize;
        public Vector3 Position => cam.transform.position;
    }
}

