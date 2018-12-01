using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreFw.Business.Abstract;
using CoreFw.Core.CrossCuttingConcerns.Security;
using CoreFw.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFw.MvcWebUI.Northwind.Controllers
{
  public class ProductController : Microsoft.AspNetCore.Mvc.Controller
  {
    private readonly IProductService _productService;
    private readonly IServiceProvider _provider;
    public ProductController(IProductService productService, IServiceProvider provider)
    {
      _productService = productService;
      _provider = provider;
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
      return View(new ProductListViewModel
      {
        Products = _productService.GetList()
      });

    }

    public IActionResult Add()
    {
      _productService.Add(new Product {  ProductName = "Elma" });
      return Content("Added");
    }
    public IActionResult Update()
    {
      _productService.Update(new Product { ProductName = "Elmax" ,ProductId = 4086 });
      return Content("Updated");
    }
    public IActionResult Delete()
    {
      _productService.Delete(new Product { ProductName = "Elmax", ProductId = 4086 });
      return Content("Deleted");
    }

    public IActionResult SignIn()
    {
      var userIdentity = new Identity()
      {
        Name = "Kerem",
        LastName = "Varış",
        Email = "webyonett@gmail.com",
        Password = "123456",
        Roles = new[] { "Admin" }
      };


      var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.AuthorizationDecision,"Product.Read"),
                new Claim(ClaimTypes.AuthorizationDecision,"Product.Write"),
                new Claim(ClaimTypes.AuthorizationDecision,"Category.Read"),
                new Claim(ClaimTypes.Role,"Admin")
            };


      var claimsIdentity = new ClaimsIdentity(userIdentity);

      //claims, CookieAuthenticationDefaults.AuthenticationScheme olmaz ise [Authorize] çalışmıyor
      var claimsIdentity2 = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

      var claimsPrincipal = new ClaimsPrincipal(new[]
      {
                claimsIdentity,
                claimsIdentity2
            });


      //CookieAuthenticationDefaults.AuthenticationScheme şeması HttpContext.User'ın default data çektiği cookiedir.
      HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);


      //Thread safe olmadığı için kayboluyor.
      //Thread.CurrentPrincipal = claimsPrincipal;

      return Content("Singed");
    }
  }
}