using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace CoreFw.DataAccess.DependencyResolvers.Autofac
{
  public class AutofacDataAccessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly)
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}
