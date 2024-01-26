using Cosmos.Data;
using Cosmos.Gameplay;
using Cosmos.Gameplay.Settings;
using Cosmos.Player;
using Cosmos.Signals;
using Cosmos.Systems;
using Cosmos.Utility;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Cosmos.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerHealthChangedSignal>();
            Container.DeclareSignal<ScoreChangedSignal>();

            Container.Bind<LevelBounds>().AsSingle();
            Container.Bind<IScoreSystem>().To<SimpleScoreSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<BoundsHandler>().AsCached();
            Container.BindInterfacesAndSelfTo<WeaponManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<InvincibilityHandler>().AsSingle();

            Container.BindMemoryPool<Bullet, Bullet.Pool>();
            Container.BindFactory<ShipSettings, Ship, Ship.Factory>().FromComponentInNewPrefabResource("Ship");

            Container.BindFactory<BulletSettings, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool<BulletSettings, Bullet, Bullet.Pool>(poolBinder => poolBinder
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource("Bullet"));

            Container.BindFactory<AsteroidSettings, Asteroid, Asteroid.Factory>()
                .FromPoolableMemoryPool<AsteroidSettings, Asteroid, Asteroid.Pool>(poolBinder => poolBinder
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource("Asteroid"));

            Container.BindInterfacesAndSelfTo<AsteroidManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();

            var configSystem = ProjectContext.Instance.Container.Resolve<IConfigurationSystem>();
            var assetSystem = ProjectContext.Instance.Container.Resolve<IAssetSystem>();

            var asteroidTypeIds = configSystem.GetAllData<AsteroidData>().Select(x => x.TypeId).ToList();

            foreach (var item in asteroidTypeIds)
            {
                var prefabRef = assetSystem.GetAsset<Transform>(item);
                Container.BindFactory<CosmosPoolableComponent, CosmosPoolableComponent.Factory>()
                .WithId(item)
                .FromPoolableMemoryPool<CosmosPoolableComponent, CosmosPoolableComponent.Pool>(poolBinder =>
                 poolBinder.WithInitialSize(10)
                .FromComponentInNewPrefab(prefabRef));
            }
        }
    }
}

