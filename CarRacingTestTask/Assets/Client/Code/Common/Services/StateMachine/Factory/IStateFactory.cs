using System;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Common.Services.StateMachine.Factory
{
    public interface IStateFactory
    {
        IStateBase Create(Type stateType);
    }
}