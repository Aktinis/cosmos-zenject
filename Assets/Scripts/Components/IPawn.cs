namespace Cosmos.Components
{
    public interface IPawn : IMove, IRotate
    {
        public void Rotate(int direction);
        public void Thrust(bool useThrust);
        public void ToggleCollision(bool state);
    }
}
