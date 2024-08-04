using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.State;
using Zenject;

namespace Client.Code.Services.Startup.Auto
{
    public class AutoStartupper<T> : IInitializable where T : IStateBase
    {
        private readonly IStateMachine _stateMachine;

        public AutoStartupper(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>();
    }
}