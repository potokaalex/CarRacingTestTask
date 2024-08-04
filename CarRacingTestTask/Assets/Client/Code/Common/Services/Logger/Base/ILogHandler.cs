namespace Client.Code.Common.Services.Logger.Base
{
    public interface ILogHandler
    {
        void Handle(LogData log);
    }
}