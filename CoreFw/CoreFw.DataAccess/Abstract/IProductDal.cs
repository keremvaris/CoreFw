using CoreFw.Core.DataAccess;
using CoreFw.Entities.Concrete;


namespace CoreFw.DataAccess.Abstract
{
  /// <summary>
  /// Burada Özel Operasyonlar yazabilirsiniz dolayısıyla Repository bağımlılığı olmadan sadece buraya özel yazabilirsiniz.
  /// </summary>
  public interface IProductDal:IEntityRepository<Product>
  {
  }
}
