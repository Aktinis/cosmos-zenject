using UnityEngine;

namespace Cosmos.Gameplay
{
    internal sealed class LevelBounds
    {
        private const float BOUNDS_OFFSET = .5f;
        private Vector2 boundsX = Vector2.zero;
        private Vector2 boundsY = Vector2.zero;

        public float Top => boundsY.y;
        public float Left => boundsX.x;
        public float Right => boundsX.y;
        public float Bottom => boundsY.x;

        public float TopOffset => Top - BOUNDS_OFFSET;
        public float LeftOffset => Left + BOUNDS_OFFSET;
        public float RightOffset => Right - BOUNDS_OFFSET;
        public float BottomOffset => Bottom + BOUNDS_OFFSET;

        public LevelBounds(CameraController cameraController)
        {
            var halfWidth = cameraController.OrthographicSize * cameraController.AspectRatio;
            var centerPosition = cameraController.Position;
            boundsX = new Vector2(centerPosition.x - halfWidth, centerPosition.x + halfWidth);
            boundsY = new Vector2(centerPosition.x - cameraController.OrthographicSize, centerPosition.x + cameraController.OrthographicSize);
        }


        public Vector3 GetRandomisedBoundPosition()
        {
            int randomizer = Random.Range(0, 101);
            float randomisedPosX = 0;
            float randomisedPosY = 0;

            if (randomizer < 50)
            {
                randomizer = Random.Range(0, 101);
                //randomise on horizontal
                randomisedPosX = Random.Range(LeftOffset, RightOffset);

                if (randomizer < 50)
                {
                    randomisedPosY = BottomOffset;
                }
                else
                {
                    randomisedPosY = TopOffset;
                }

            }
            else
            {
                randomizer = Random.Range(0, 101);
                //randomise on vertical
                randomisedPosY = Random.Range(BottomOffset, TopOffset);

                if (randomizer < 50)
                {
                    randomisedPosX = LeftOffset;
                }
                else
                {
                    randomisedPosX = RightOffset;
                }

            }

            return new Vector3(randomisedPosX, randomisedPosY);
        }
    }
}

