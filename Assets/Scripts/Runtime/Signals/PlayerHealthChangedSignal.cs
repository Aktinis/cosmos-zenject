namespace Cosmos.Signals
{
    internal readonly struct PlayerHealthChangedSignal
    {
        public int PlayerHealth { get; }
        public PlayerHealthChangedSignal(int playerHealth)
        {
            PlayerHealth = playerHealth;
        }
    }
}

