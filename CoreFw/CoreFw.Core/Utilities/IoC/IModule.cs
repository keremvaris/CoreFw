using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.Core.Utilities.IoC
{
  public interface IModule
  {
    void Load(IServiceCollection service);
  }
}
