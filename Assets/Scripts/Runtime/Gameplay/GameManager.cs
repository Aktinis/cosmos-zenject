using Cosmos.Data;
using Cosmos.Gameplay.Settings;
using Cosmos.Player;
using Cosmos.Signals;
using Cosmos.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Cosmos.Gameplay
{
    internal sealed class GameManager : IInitializable, ITickable
    {
        private const float DELAY_EXIT_TIME = 3f;

        private readonly IConfigurationSystem configurationSystem;
        private readonly ISceneManagingSystem sceneManagingSystem;
        private readonly PlayerController playerController =null;
        private readonly LevelManager levelManager = null;
        private readonly Ship.Factory shipFactory = null;
        private readonly SignalBus signalBus = null;
        private float delayStartTime;

        public GameManager(PlayerController playerController, Ship.Factory shipFactory, LevelManager levelManager,
            IConfigurationSystem configurationSystem, SignalBus signalBus, ISceneManagingSystem sceneManagingSystem)
        {
            this.signalBus = signalBus;
            this.shipFactory = shipFactory;
            this.playerController = playerController;
            this.levelManager = levelManager;
            this.configurationSystem = configurationSystem;
            this.sceneManagingSystem = sceneManagingSystem;
        }

        public void Initialize()
        {
            var shipData = configurationSystem.GetDefaultData<ShipData>();
            var ship = shipFactory.Create(new ShipSettings(Vector3.zero, shipData));
            var bulletData = configurationSystem.GetDefaultData<BulletData>();

            signalBus.Fire(new PlayerHealthChangedSignal(shipData.Health));
            playerController.Possess(ship);
            playerController.AddWeapon(bulletData);
            levelManager.Start();
            Debug.Log("Game has started!");
        }

        public void Tick()
        {
            if (playerController.IsAlive() == false)
            {
                if (delayStartTime > DELAY_EXIT_TIME)
                {
                    levelManager.End();
                    Debug.Log("Game has ended!");
                    sceneManagingSystem.LoadSceneAsync("Menu");
                }
                delayStartTime += Time.deltaTime;
            }
        }
    }
}

