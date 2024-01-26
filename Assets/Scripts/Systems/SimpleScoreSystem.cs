using Cosmos.Data;
using Cosmos.Signals;
using Zenject;

namespace Cosmos.Systems
{
    public interface IScoreSystem
    {
        public void UpdateScore(string typeId);
        public int GetScore();
    }

    public sealed class SimpleScoreSystem : IScoreSystem
    {
        private readonly IConfigurationSystem configurationSystem;
        private readonly SignalBus signalBus;

        public SimpleScoreSystem(IConfigurationSystem configurationSystem, SignalBus signalBus)
        {
            this.signalBus = signalBus;
            this.configurationSystem = configurationSystem;
        }

        private int score = 0;

        public int GetScore()
        {
            return score;
        }

        public void UpdateScore(string typeId)
        {
            this.score += configurationSystem.GetData<AsteroidData>(typeId).Points;
            signalBus.Fire(new ScoreChangedSignal(score));
        }
    }
}

