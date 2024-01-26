namespace Cosmos.Gameplay.Providers
{
    public interface IHealthProvider
    {
        public bool IsAlive { get; }
        public int Health { get; }
    }
}
