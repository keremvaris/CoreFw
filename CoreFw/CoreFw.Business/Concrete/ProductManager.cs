using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFw.Business.Abstract;
using CoreFw.DataAccess.Abstract;
using CoreFw.Entities.Concrete;

namespace CoreFw.Business.Concrete
{

  public class ProductManager:IProductService
  {
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
      _productDal = productDal;
    }


    public List<Product> GetAll()
    {
      return _productDal.GetList();
    }
  }
}
