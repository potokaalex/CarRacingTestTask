using System;
using Client.Code.Services.StateMachine.Factory;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.StateMachine
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IStateFactory _factory;
        private IStateBase _currentState;

        public StateMachine(IStateFactory factory) => _factory = factory;

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

            DebugOnExit();
            if (_currentState is IState state)
                state.Exit();
            else if (_currentState is IStateAsync asyncState)
                await asyncState.Exit();
        }

        private protected string GetCurrentStateName() => _currentState.GetType().Name; //used in debug!

        private protected virtual void DebugOnExit()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Exit: {GetCurrentStateName()}");
#endif
        }

        private protected virtual void DebugOnEnter()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Enter: {GetCurrentStateName()}");
#endif
        }
    }
}