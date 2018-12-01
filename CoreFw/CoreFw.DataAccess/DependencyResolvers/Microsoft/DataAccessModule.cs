using System;
using System.Collections.Generic;
using System.Text;
using CoreFw.Core.Utilities.IoC;
using CoreFw.DataAccess.Abstract;
using CoreFw.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.DataAccess.DependencyResolvers.Microsoft
{
  public class DataAccessModule : IModule
  {
    public void Load(IServiceCollection service)
    {
      service.AddSingleton<IProductDal, EfProductDal>();
    }
  }
}
