using Client.Code.Common.Services.StateMachine.Factory;

namespace Client.Code.Common.Services.StateMachine.Global
{
    public class GlobalStateMachine : StateMachine, IGlobalStateMachine
    {
        public GlobalStateMachine(IStateFactory factory) : base(factory)
        {
        }

        private protected override void DebugOnExit()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Exit: {GetCurrentStateName()}-global");
#endif
        }

        private protected override void DebugOnEnter()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Enter: {GetCurrentStateName()}-global");
#endif
        }
    }
}