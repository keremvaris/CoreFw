using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CoreFw.Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.Core.CrossCuttingConcerns.Caching.Microsoft
{
  public class MemoryCacheManager : ICacheManager
  {
    private readonly IMemoryCache _cache;

    public MemoryCacheManager()
    {
      _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public T Get<T>(string key)
    {
      return _cache.Get<T>(key);
    }

    public object Get(string key)
    {
      return _cache.Get(key);
    }

    public void Add(string key, object data, int duration)
    {
      //var options = new MemoryCacheEntryOptions()
      //    .SetSlidingExpiration(TimeSpan.FromMinutes(duration))
      //    .SetAbsoluteExpiration(TimeSpan.FromMinutes(duration));

      _cache.Set(key, data, TimeSpan.FromMinutes(duration));

    }

    public bool IsAdd(string key)
    {
      return _cache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
      _cache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
      var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public void Clear()
    {
    }
  }
}
