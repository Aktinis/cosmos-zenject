using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cosmos.UI
{

    public sealed class MenuView : View
    {
        private const string START_GAME_TEXT = "Click anywhere to start";
        private const string CONTROLS_TEXT = "W -> Move forward\nA,D -> Rotate ship\n SPACE -> Fire\nT -> Teleport to random location";

        [SerializeField] private Button startGameButton = null;
        [SerializeField] private TextMeshProUGUI controlsTextField = null;
        [SerializeField] private TextMeshProUGUI startGameTextField = null;

        public void AddStartGameListener(Action callback)
        {
            startGameButton.onClick.AddListener(callback.Invoke);
        }
        private void Start()
        {
            startGameTextField.text = START_GAME_TEXT;
            controlsTextField.text = CONTROLS_TEXT;
        }
        private void OnDestroy()
        {
            startGameButton.onClick.RemoveAllListeners();
        }
    }
}

