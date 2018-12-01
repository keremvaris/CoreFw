using System.Collections.Generic;
namespace CoreFw.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
