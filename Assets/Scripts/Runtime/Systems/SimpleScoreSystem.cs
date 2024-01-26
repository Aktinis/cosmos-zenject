using Cosmos.Data;
using Cosmos.Signals;
using Zenject;

namespace Cosmos.Systems
{
    internal sealed class SimpleScoreSystem : IScoreSystem
    {
        private readonly IConfigurationSystem configurationSystem;
        private readonly SignalBus signalBus;
        private int score = 0;

        public SimpleScoreSystem(IConfigurationSystem configurationSystem, SignalBus signalBus)
        {
            this.signalBus = signalBus;
            this.configurationSystem = configurationSystem;
        }

        public int GetScore()
        {
            return score;
        }

        public void UpdateScore(string typeId)
        {
            score += configurationSystem.GetData<AsteroidData>(typeId).Points;
            signalBus.Fire(new ScoreChangedSignal(score));
        }
    }
}

