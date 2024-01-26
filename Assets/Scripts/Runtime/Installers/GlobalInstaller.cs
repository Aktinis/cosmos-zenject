using Cosmos.Systems;
using Zenject;

namespace Cosmos.Installer
{
    internal sealed class GlobalInstaller : MonoInstaller<GlobalInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetSystem>().To<ResourceSystem>().AsSingle();
            Container.Bind<IConfigurationSystem>().To<SimpleConfigurationSystem>().AsSingle();
        }
    }
}



