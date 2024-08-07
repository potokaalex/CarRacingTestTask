namespace Client.Code.Common.Services.StateMachine
{
    public static class StateMachineConstants
    {
        public static readonly bool IsDebug;

        static StateMachineConstants()
        {
#if DEBUG_STATE_MACHINE
            IsDebug = true;
#else
            IsDebug = false;
#endif
        }
    }
}