namespace Cosmos.Components
{
    public interface IHealth
    {
        public bool IsAlive { get; }
        public int Health { get; }
    }
}
