using Client.Code.Common.Services.Logger.Base;
using UnityEngine;
using ILogHandler = Client.Code.Common.Services.Logger.Base.ILogHandler;

namespace Client.Code.Common.Services.Logger
{
    using ILogHandler = ILogHandler;

    public class LoggerByUnityLog : ILogHandler
    {
        public void Handle(LogData log) => Debug.Log($"<color=green>Log:</color> {log.Message}");
    }
}