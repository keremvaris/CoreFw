using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFw.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreFw.MvcWebUI.Northwind.Controllers
{
  public class ProductController : Controller
    {
      private IProductService _productService;

      public ProductController(IProductService productService)
      {
        _productService = productService;
      }

      public ActionResult Index()
      {
        var products = _productService.GetAll();
        ProductListViewModel model=new ProductListViewModel
        {
          Products =products
        };
            return View(model);
        }
    }
}