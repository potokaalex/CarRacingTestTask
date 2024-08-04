using Client.Code.Common.Services.Startup;
using Client.Code.CompositionRoot.Infrastructure.States;
using Zenject;

namespace Client.Code.CompositionRoot.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<AutoStartupperGlobal<ProjectLoadState>>().AsSingle();
    }
}