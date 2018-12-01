using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using CoreFw.Business.Abstract;
using CoreFw.Business.BusinessAspects.Security;
using CoreFw.Business.ValidationRules.FluentValidation;
using CoreFw.Core.Aspects.AutoFac.Caching;
using CoreFw.Core.Aspects.AutoFac.Logging;
using CoreFw.Core.Aspects.AutoFac.Performance;
using CoreFw.Core.Aspects.AutoFac.Transaction;
using CoreFw.Core.Aspects.AutoFac.Validation;
using CoreFw.Core.CrossCuttingConcerns.Caching.Microsoft;
using CoreFw.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CoreFw.DataAccess.Abstract;
using CoreFw.Entities.Concrete;

namespace CoreFw.Business.Concrete
{

  public class ProductManager : IProductService
  {
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
      _productDal = productDal;
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
      return _productDal.Get(filter);
    }

    [LogInterceptionAspect(typeof(FileLogger))]
    //[SecurityOperationInterceptorAspect("Product.Read")]
    [PerformanceInterceptionAspect(0)]
    [CacheInterceptionAspect(typeof(MemoryCacheManager))]
    public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
    {
      //Thread.Sleep(3000);
      return _productDal.GetList(filter).ToList();
      
    }
    [TransactionInterceptionAspect]
    [CacheRemoveInterceptionAspect("*Get*")]
    [ValidationInterceptionAspect(typeof(ProductValidation))]
    public void Add(Product product)
    {
      _productDal.Add(product);
    }

    public void Update(Product product)
    {
      _productDal.Update(product);
    }

    public void DeleteById(int id)
    {
      var product = Get(p => p.ProductId == id);
      _productDal.Delete(product);
    }

    public void Delete(Product product)
    {
      _productDal.Delete(product);
    }
  }
}
