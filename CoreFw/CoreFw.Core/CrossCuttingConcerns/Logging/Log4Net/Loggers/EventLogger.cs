using log4net;

namespace CoreFw.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class EventLogger:LoggerService
    {
        public EventLogger() : base(LogManager.GetLogger(typeof(EventLogger)))
        {
        }
    }
}
