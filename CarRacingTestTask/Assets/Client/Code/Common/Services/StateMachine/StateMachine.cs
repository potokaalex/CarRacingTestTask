using System;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.StateMachine
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IStateFactory _factory;
        private readonly ILogReceiver _logReceiver;
        private IStateBase _currentState;

        public StateMachine(IStateFactory factory, ILogReceiver logReceiver)
        {
            _factory = factory;
            _logReceiver = logReceiver;
        }

        public void SwitchTo<T>() where T : IStateBase => SwitchTo(typeof(T));

        public void SwitchTo(Type stateType) => SwitchToAsync(stateType).Forget();

        public void Dispose() => ExitAsync().Forget();

        private async UniTask SwitchToAsync(Type stateType)
        {
            await ExitAsync();
            _currentState = _factory.Create(stateType);
            await EnterAsync();
        }

        private async UniTask EnterAsync()
        {
            if (StateMachineConstants.IsDebug)
                DebugOnEnter();

            if (_currentState is IState state)
                state.Enter();
            else if (_currentState is IStateAsync asyncState)
                await asyncState.Enter();
        }

        private async UniTask ExitAsync()
        {
            if (_currentState == null)
                return;

            if (StateMachineConstants.IsDebug)
                DebugOnExit();

            if (_currentState is IStateWithExit state)
                state.Exit();
            else if (_currentState is IStateWithExitAsync asyncState)
                await asyncState.Exit();
        }

        private protected string GetCurrentStateName() => _currentState.GetType().Name;

        private protected virtual void DebugOnExit() => _logReceiver.Log(new LogData { Message = $"Exit: {GetCurrentStateName()}" });

        private protected virtual void DebugOnEnter() => _logReceiver.Log(new LogData { Message = $"Enter: {GetCurrentStateName()}" });
    }
}