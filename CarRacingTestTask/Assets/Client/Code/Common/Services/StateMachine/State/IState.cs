namespace Client.Code.Common.Services.StateMachine.State
{
    public interface IState : IStateBase
    {
        void Enter();
        void Exit();
    }
}