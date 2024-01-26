using Cosmos.Signals;
using Zenject;

namespace Cosmos.UI
{
    public sealed class HudController : UIController<HudView>
    {
        private SignalBus signalBus = null;

        protected override void OnStart()
        {
            view.UpdateScore(0);
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
            signalBus.Subscribe<PlayerHealthChangedSignal>(OnPlayerHealthChanged);
            signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
        }

        private void OnPlayerHealthChanged(PlayerHealthChangedSignal signal)
        {
            view.UpdateLives(signal.PlayerHealth);
        }      
        
        private void OnScoreChanged(ScoreChangedSignal signal)
        {
            view.UpdateScore(signal.Score);
        }

        private void OnDestroy()
        {
            signalBus.Unsubscribe<PlayerHealthChangedSignal>(OnPlayerHealthChanged);
            signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
        }
    }
}
