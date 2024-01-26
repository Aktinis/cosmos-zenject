namespace Cosmos.Signals
{
    public readonly struct PlayerHealthChangedSignal
    {
        public int PlayerHealth { get; }
        public PlayerHealthChangedSignal(int playerHealth)
        {
            PlayerHealth = playerHealth;
        }
    }
}

