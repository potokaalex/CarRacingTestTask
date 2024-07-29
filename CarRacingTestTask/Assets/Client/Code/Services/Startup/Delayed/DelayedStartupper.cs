using Client.Code.Services.StateMachine.State;
using Zenject;

namespace Client.Code.Services.Startup.Delayed
{
    public class DelayedStartupper<T> : IInitializable where T : IStateAsync
    {
        private readonly IInstantiator _instantiator;

        public DelayedStartupper(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize() => _instantiator.InstantiateComponentOnNewGameObject<DelayedStartupperMono>(new[] { typeof(T) });
    }
}