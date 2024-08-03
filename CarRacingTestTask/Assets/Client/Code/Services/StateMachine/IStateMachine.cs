using System;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Services.StateMachine
{
    public interface IStateMachine
    {
        void SwitchTo<T>() where T : IStateBase;
        void SwitchTo(Type stateType);
    }
}