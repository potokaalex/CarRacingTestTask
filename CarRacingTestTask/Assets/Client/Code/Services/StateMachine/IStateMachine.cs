using System;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Services.StateMachine
{
    public interface IStateMachine
    {
        void SwitchTo<T>() where T : IStateAsync;
        void SwitchTo(Type stateType);
    }
}