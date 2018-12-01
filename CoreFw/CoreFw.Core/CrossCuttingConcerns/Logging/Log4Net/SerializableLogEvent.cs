using log4net.Core;

namespace CoreFw.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        //Buarada dışardan değerler alarak uygulamamıza özel değerleride loga yazıdrabiliriz.
        //Örneğin Asp.net session id yi tutmak gibi.
        private readonly LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;

    }
}
