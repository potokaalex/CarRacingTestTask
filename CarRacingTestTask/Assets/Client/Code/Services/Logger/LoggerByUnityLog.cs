using Client.Code.Services.Logger.Base;
using UnityEngine;

namespace Client.Code.Services.Logger
{
    using ILogHandler = Base.ILogHandler;

    public class LoggerByUnityLog : ILogHandler
    {
        public void Handle(LogData log) => Debug.Log($"<color=yellow>Log:</color> {log.Message}");
    }
}