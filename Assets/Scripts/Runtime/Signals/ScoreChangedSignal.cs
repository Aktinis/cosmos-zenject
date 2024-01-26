namespace Cosmos.Signals
{
    internal readonly struct ScoreChangedSignal
    {
        public int Score { get; }
        public ScoreChangedSignal(int score)
        {
            Score = score;
        }
    }
}

