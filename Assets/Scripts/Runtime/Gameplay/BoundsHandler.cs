using Cosmos.Gameplay.Providers;
using UnityEngine;

namespace Cosmos.Gameplay
{
    internal sealed class BoundsHandler
    {
        private readonly LevelBounds levelBounds;

        public BoundsHandler(LevelBounds levelBounds)
        {
            this.levelBounds = levelBounds;
        }

        public void UpdatePosition(IPositionProvider movable)
        {
            var newPosition = movable.Position;
            if (newPosition.x < levelBounds.Left || newPosition.x > levelBounds.Right)
            {
                newPosition = new Vector3(newPosition.x * -1, newPosition.y);
            }

            if (newPosition.y < levelBounds.Bottom || newPosition.y > levelBounds.Top)
            {
                newPosition = new Vector3(newPosition.x, newPosition.y * -1);
            }

            if(movable.Position != newPosition)
            {
                movable.Position = ClampPositionToBounds(newPosition);
            }
        }
        
        public void Teleport(IPositionProvider movable)
        {
            var randomPosX = Random.Range(levelBounds.LeftOffset, levelBounds.RightOffset);
            var randomPosY = Random.Range(levelBounds.BottomOffset, levelBounds.TopOffset);
            var newPosition = new Vector3(randomPosX, randomPosY);
            movable.Position = newPosition;
        }

        private Vector3 ClampPositionToBounds(Vector3 position)
        {
            return new Vector3(Mathf.Clamp(position.x, levelBounds.LeftOffset, levelBounds.RightOffset), 
                Mathf.Clamp(position.y, levelBounds.BottomOffset, levelBounds.TopOffset));
        }
    }
}

