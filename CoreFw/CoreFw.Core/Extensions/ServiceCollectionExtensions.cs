using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreFw.Core.Utilities.IoC;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Module = Autofac.Module;

namespace CoreFw.Core.Extensions
{
  public static class ServiceCollectionExtensions
  {
    private static IContainer _container;
    /// <summary>
    /// Her katmanın çözümleme modülleri IServiceCollection'a ekleniyor.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="modules"></param>
    /// <returns></returns>
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, IModule[] modules)
    {
      foreach (var module in modules)
      {
        module.Load(service);
      }
      return ServiceTool.Create(service);
    }
    /// <summary>
    /// Daha önce IServiceCollection tarafında yapılan çözümlemeleri dolduruyor.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="modules"></param>
    /// <returns></returns>
    public static IServiceCollection AddAutofacDependencyResolvers(this IServiceCollection services, Module[] modules)
    {

      var builder = new ContainerBuilder();
      builder.Populate(services);

      foreach (var module in modules)
      {
        builder.RegisterModule(module);
      }

      _container = builder.Build();

      return services;
    }

    public static IServiceProvider CreateAutofacServiceProvider(this IServiceCollection services)
    {
      return new AutofacServiceProvider(_container);
    }
    public static IServiceCollection AddLog4Net(this IServiceCollection services)
    {
      //TODO:Dikkat => Log4Net 2.0.5 sürümde çalışaktadır. Üst sürümlerde hata vermektedir.
      var assembly = Assembly.GetEntryAssembly();
      var logRepository = LogManager.GetRepository(assembly);
      XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

      return services;
    }
  }
}
