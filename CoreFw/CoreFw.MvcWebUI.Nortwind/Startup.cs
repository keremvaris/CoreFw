using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFw.Business.Abstract;
using CoreFw.Business.Concrete;
using CoreFw.Core.DataAccess;
using CoreFw.Core.DataAccess.EntityFramework;
using CoreFw.DataAccess.Abstract;
using CoreFw.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreFw.MvcWebUI.Northwind
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
     
      services.AddScoped<IProductService, ProductManager>();
      services.AddScoped<IProductDal, EfProductDal>();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvcWithDefaultRoute();
    }
  }
}
