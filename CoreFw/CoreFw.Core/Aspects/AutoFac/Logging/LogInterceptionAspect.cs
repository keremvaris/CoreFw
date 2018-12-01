using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using CoreFw.Core.CrossCuttingConcerns.Logging;
using CoreFw.Core.Utilities.Intercepters;

namespace CoreFw.Core.Aspects.AutoFac.Logging
{
  public class LogInterceptionAspect : MethodInterception
  {
    private readonly LoggerService _loggerService;

    public LogInterceptionAspect(Type loggerType)
    {
      if (loggerType.BaseType != typeof(LoggerService))
      {
        throw new Exception("Wrong Logger Type");
      }
      _loggerService = (LoggerService)Activator.CreateInstance(loggerType);
    }

    protected override void OnBefore(IInvocation invocation)
    {
      var logParameters = invocation.Method.GetParameters()
        .Select((t, i) => new LogParameter
        {
          Name = t.Name,
          Type = t.ParameterType.Name,
          Value = invocation.Arguments[i]
        }).ToList();

      var logDetail = new LogDetail
      {
        FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
        MethodName = invocation.Method.Name,
        LogParameters = logParameters
      };

      _loggerService.Debug(logDetail);
    }
  }
}
