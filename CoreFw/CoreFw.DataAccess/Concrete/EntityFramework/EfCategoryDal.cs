using CoreFw.Core.DataAccess.EntityFramework;
using CoreFw.DataAccess.Abstract;
using CoreFw.DataAccess.Concrete.EntityFramework.Contexts;
using CoreFw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreFw.DataAccess.Concrete.EntityFramework
{
  public class EfCategoryDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
  {
    public EfCategoryDal(DbSet<Product> entities) : base(entities)
    {
    }
  }
}
