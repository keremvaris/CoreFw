using log4net;

namespace CoreFw.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger:LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger(typeof(FileLogger)))
        {
        }
    }
}
