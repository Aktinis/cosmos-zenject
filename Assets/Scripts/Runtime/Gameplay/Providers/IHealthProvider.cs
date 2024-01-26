namespace Cosmos.Gameplay.Providers
{
    internal interface IHealthProvider
    {
        public bool IsAlive { get; }
        public int Health { get; }
    }
}
