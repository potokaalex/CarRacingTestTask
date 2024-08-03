using Client.Code.Infrastructure.States;
using Client.Code.Infrastructure.States.Project;
using Client.Code.Services.Startup.Auto;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<AutoStartupperGlobal<ProjectLoadState>>().AsSingle();
    }
}