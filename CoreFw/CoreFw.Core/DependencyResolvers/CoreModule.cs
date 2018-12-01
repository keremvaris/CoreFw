using System.Diagnostics;
using CoreFw.Core.CrossCuttingConcerns.Caching;
using CoreFw.Core.CrossCuttingConcerns.Caching.Microsoft;
using CoreFw.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.Core.DependencyResolvers
{
  public class CoreModule : IModule
  {
    public void Load(IServiceCollection service)
    {
      service.AddMemoryCache();
      service.AddSingleton<ICacheManager, MemoryCacheManager>();
      service.AddSingleton<Stopwatch>();
    }
  }
}
