using CoreFw.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreFw.DataAccess.Tests
{
  [TestClass]
  public class ProductDalTests
  {
    [TestMethod]
    public void ShouldMustComeAllProducts()
    {
      var productDal = new EfProductDal();
      var products = productDal.GetList();

      Assert.AreEqual(products.Count, 78);
    }
  }
}
