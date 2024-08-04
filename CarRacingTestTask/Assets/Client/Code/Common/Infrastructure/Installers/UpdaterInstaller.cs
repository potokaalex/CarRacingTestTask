using Client.Code.Common.Services.Updater;
using Zenject;

namespace Client.Code.Common.Infrastructure.Installers
{
    public class UpdaterInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
    }
}