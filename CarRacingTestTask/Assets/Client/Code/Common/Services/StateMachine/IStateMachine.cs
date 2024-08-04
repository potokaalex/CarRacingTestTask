using System;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Common.Services.StateMachine
{
    public interface IStateMachine
    {
        void SwitchTo<T>() where T : IStateBase;
        void SwitchTo(Type stateType);
    }
}