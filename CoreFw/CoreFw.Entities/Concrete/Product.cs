using CoreFw.Core.Entities;

namespace CoreFw.Entities.Concrete
{
  public class Product:IEntity
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; }
  }
}
