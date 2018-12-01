using System.ComponentModel.DataAnnotations;
using CoreFw.Business.Concrete;
using CoreFw.DataAccess.Abstract;
using CoreFw.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoreFw.Business.Test
{
  [TestClass]
  public class ProductManagerTests
  {
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void FluentValidationCheck()
    {
      var productDalMock = new Mock<IProductDal>();

      var productManager = new ProductManager(productDalMock.Object);

      productManager.Add(new Product
      {
        ProductId = 1,
        ProductName = "A"
      });
    }
  }
}
