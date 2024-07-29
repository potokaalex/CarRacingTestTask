using System;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Services.StateMachine.Factory
{
    public interface IStateFactory
    {
        IStateAsync Create(Type stateType);
    }
}