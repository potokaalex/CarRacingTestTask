using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Zenject;

namespace Client.Code.Common.Services.Startup
{
    public class AutoStartupperGlobal<T> : IInitializable where T : IStateBase
    {
        private readonly IGlobalStateMachine _stateMachine;

        public AutoStartupperGlobal(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>();
    }
}