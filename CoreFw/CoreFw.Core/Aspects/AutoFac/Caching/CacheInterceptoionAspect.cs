using System;
using System.Linq;
using Castle.DynamicProxy;
using CoreFw.Core.CrossCuttingConcerns;
using CoreFw.Core.CrossCuttingConcerns.Caching;
using CoreFw.Core.Utilities.Intercepters;
using CoreFw.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.Core.Aspects.AutoFac.Caching
{
  public class CacheInterceptionAspect : MethodInterception
  {
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;

    public CacheInterceptionAspect(Type cacheType, int duration = 60)
    {
      if (!typeof(ICacheManager).IsAssignableFrom(cacheType))
      {
        throw new Exception("Wrong cache type");
      }
      //_cacheManager = (ICacheManager)Activator.CreateInstance(cacheType);
      _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
      _duration = duration;
    }

    public override void Intercept(IInvocation invocation)
    {
      var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

      var arguments = invocation.Arguments.ToList();

      var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

      if (_cacheManager.IsAdd(key))
      {
        invocation.ReturnValue = _cacheManager.Get(key);
        return;
      }
      invocation.Proceed();
      _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
  }
}
