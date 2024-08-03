namespace Client.Code.Services.Logger.Base
{
    public interface ILogHandler
    {
        void Handle(LogData log);
    }
}