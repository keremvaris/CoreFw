using System.Collections.Generic;
using CoreFw.Entities.Concrete;

namespace CoreFw.Business.Abstract
{
  /// <summary>
  /// Dış dünyaya servis edilecek hizmetleri içerir. Clientların ihtiyaç duyduğu operasyonları buraya yazabilirsiniz. mvc mobil vb.
  /// </summary>

  public interface IProductService
  {
    List<Product> GetAll();
  }
}
