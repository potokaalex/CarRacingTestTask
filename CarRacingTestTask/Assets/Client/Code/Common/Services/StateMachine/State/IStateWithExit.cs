﻿namespace Client.Code.Common.Services.StateMachine.State
{
    public interface IStateWithExit : IState
    {
        void Exit();
    }
}