using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.StateMachine.Factory;

namespace Client.Code.Common.Services.StateMachine.Global
{
    public class GlobalStateMachine : StateMachine, IGlobalStateMachine
    {
        private readonly ILogReceiver _logReceiver;

        public GlobalStateMachine(IStateFactory factory, ILogReceiver logReceiver) : base(factory, logReceiver) => _logReceiver = logReceiver;

        private protected override void DebugOnExit() => _logReceiver.Log(new LogData { Message = $"Exit: {GetCurrentStateName()}-global" });

        private protected override void DebugOnEnter() => _logReceiver.Log(new LogData { Message = $"Enter: {GetCurrentStateName()}-global" });
    }
}