namespace Client.Code.Common.Services.Logger.Base
{
    public interface ILogReceiver
    {
        void Log(LogData log);
        void RegisterHandler(ILogHandler handler);
        void UnRegisterHandler(ILogHandler handler);
    }
}