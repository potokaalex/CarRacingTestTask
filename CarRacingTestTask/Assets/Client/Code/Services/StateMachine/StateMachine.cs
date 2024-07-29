using System;
using Client.Code.Services.StateMachine.Factory;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.StateMachine
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IStateFactory _factory;
        private IStateAsync _currentState;

        public StateMachine(IStateFactory factory) => _factory = factory;

        public void SwitchTo<T>() where T : IStateAsync => SwitchTo(typeof(T));

        public void SwitchTo(Type stateType) => SwitchToAsync(stateType).Forget();

        public void Dispose() => ExitAsync().Forget();

        public async UniTask SwitchToAsync(Type stateType)
        {
            await ExitAsync();
            _currentState = _factory.Create(stateType);
            await EnterAsync();
        }

        private async UniTask EnterAsync()
        {
            DebugOnEnter();
            await _currentState.Enter();
        }

        private async UniTask ExitAsync()
        {
            if (_currentState != null)
            {
                DebugOnExit();
                await _currentState.Exit();
            }
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