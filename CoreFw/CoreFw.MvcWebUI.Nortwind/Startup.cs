using System;
using System.Security.Claims;
using Autofac;
using CoreFw.Business.DependencyResolvers.Autofac;
using CoreFw.Core.DependencyResolvers;
using CoreFw.Core.Extensions;
using CoreFw.Core.Utilities.IoC;
using CoreFw.DataAccess.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace CoreFw.MvcWebUI.Northwind
{
  public class Startup
  {
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddLog4Net();

      services.AddAuthentication(options =>
        {
          options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie();

      services.AddTransient<ClaimsPrincipal>(x => x.GetService<IHttpContextAccessor>().HttpContext.User);

      services.AddDependencyResolvers(new IModule[]
      {
        new CoreModule(),
      });

      services.AddAutofacDependencyResolvers(new Module[]
      {
        new AutofacDataAccessModule(),
        new AutofacBusinessModule()
      });

      return services.CreateAutofacServiceProvider();
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      //Dikkat => UseAuthentication, UseMvc'den önce çağrılmalıdır.
      app.UseAuthentication();
      app.UseMvc(routes =>
      {
        routes.MapRoute("default", "{controller=Product}/{action=Index}/{id?}");
      });
    }
  }
}
