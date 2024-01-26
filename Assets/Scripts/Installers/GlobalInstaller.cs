using Cosmos.Systems;
using Zenject;

namespace Cosmos.Installer
{
    public class GlobalInstaller : MonoInstaller<GlobalInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetSystem>().To<ResourceSystem>().AsSingle();
            Container.Bind<IConfigurationSystem>().To<SimpleConfigurationSystem>().AsSingle();
        }
    }
}



