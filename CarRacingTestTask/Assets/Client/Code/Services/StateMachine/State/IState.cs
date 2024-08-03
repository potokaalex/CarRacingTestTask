namespace Client.Code.Services.StateMachine.State
{
    public interface IState : IStateBase
    {
        void Enter();
        void Exit();
    }
}