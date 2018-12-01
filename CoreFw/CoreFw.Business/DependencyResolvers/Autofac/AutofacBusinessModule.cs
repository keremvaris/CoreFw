using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using CoreFw.Core.Utilities.Intercepters;
using Module = Autofac.Module;

namespace CoreFw.Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly)
        .AsImplementedInterfaces()
        .EnableInterfaceInterceptors(new ProxyGenerationOptions()
        {
          Selector = new AspectInterceptorSelector()
        })
        .SingleInstance();
    }
  }
}
