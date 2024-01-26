namespace Cosmos.Gameplay.Providers
{
    public interface IPawn : IPositionProvider, IRotationProvider
    {
        public void Rotate(int direction);
        public void Thrust(bool useThrust);
        public void ToggleCollision(bool state);
    }
}
