namespace Cosmos.Signals
{
    public readonly struct ScoreChangedSignal
    {
        public int Score { get; }
        public ScoreChangedSignal(int score)
        {
            Score = score;
        }
    }
}

