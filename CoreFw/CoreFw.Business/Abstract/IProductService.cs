using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreFw.Core.Business;
using CoreFw.Entities.Concrete;

namespace CoreFw.Business.Abstract
{
  /// <summary>
  /// Dış dünyaya servis edilecek hizmetleri içerir. Clientların ihtiyaç duyduğu operasyonları buraya yazabilirsiniz. mvc mobil vb.
  /// </summary>

  public interface IProductService : IServiceRepository<Product>
  {
    Product Get(Expression<Func<Product, bool>> filter);
    List<Product> GetList(Expression<Func<Product, bool>> filter = null);
    void Add(Product product);
    void Update(Product product);
    void DeleteById(int id);
    void Delete(Product product);

  }
}
