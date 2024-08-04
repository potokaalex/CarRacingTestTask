using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;
using Zenject;

namespace Client.Code.Services.Startup.Auto
{
    public class AutoStartupperGlobal<T> : IInitializable where T : IStateBase
    {
        private readonly IGlobalStateMachine _stateMachine;

        public AutoStartupperGlobal(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>();
    }
}