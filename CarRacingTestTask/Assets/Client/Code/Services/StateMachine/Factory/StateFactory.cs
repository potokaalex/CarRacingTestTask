using System;
using Client.Code.Services.StateMachine.State;
using Zenject;

namespace Client.Code.Services.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _container;

        public StateFactory(IInstantiator container) => _container = container;

        public IStateAsync Create(Type stateType) => (IStateAsync)_container.Instantiate(stateType);
    }
}