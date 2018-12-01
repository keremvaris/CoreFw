using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFw.Business.Abstract;
using CoreFw.Business.Concrete;
using CoreFw.Core.Utilities.IoC;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFw.Business.DependencyResolvers.Microsoft
{
  public class BusinessModule : IModule
  {
    public void Load(IServiceCollection service)
    {
      service.AddSingleton<IProductService, ProductManager>();
    }

    private static IEnumerable<Type> FluentValidationTypes()
    {
      var types = AppDomain.CurrentDomain
        .GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(IValidator).IsAssignableFrom(p));
      return types;
    }
  }
}
