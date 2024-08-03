using System;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Services.StateMachine.Factory
{
    public interface IStateFactory
    {
        IStateBase Create(Type stateType);
    }
}