using log4net;

namespace CoreFw.Core.CrossCuttingConcerns.Logging
{
    public abstract class LoggerService
    {
        private readonly ILog _log;

        protected LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled()
        {
            return _log.IsInfoEnabled;
        }

        public bool IsDebugEnabled()
        {
            return _log.IsDebugEnabled;
        }

        public bool IsWarnEnabled()
        {
            return _log.IsWarnEnabled;
        }

        public bool IsErrorEnabled()
        {
            return _log.IsErrorEnabled;
        }

        public bool IsFatalEnabled()
        {
            return _log.IsFatalEnabled;
        }

        public void Info(object logMessage)
        {
            if (IsInfoEnabled())
            {
                _log.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled())
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled())
            {
                _log.Warn(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled())
            {
                _log.Error(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsInfoEnabled())
            {
                _log.Fatal(logMessage);
            }
        }
    }
}
