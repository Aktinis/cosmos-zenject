using TMPro;
using UnityEngine;

namespace Cosmos.UI
{
    internal sealed class HudView : View
    {
        private const string LIVES_TEXT = "Lives left";

        [SerializeField] private TextMeshProUGUI scoreTextField = null;
        [SerializeField] private TextMeshProUGUI livesTextField = null;

        public void UpdateScore(int score)
        {
            scoreTextField.text = score.ToString();
        }

        public void UpdateLives(int amount)
        {
            livesTextField.text = $"{LIVES_TEXT}: {amount}";
        }
    }
}

