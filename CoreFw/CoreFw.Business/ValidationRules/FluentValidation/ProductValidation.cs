using System;
using System.Collections.Generic;
using System.Text;
using CoreFw.Entities.Concrete;
using FluentValidation;

namespace CoreFw.Business.ValidationRules.FluentValidation
{
  public class ProductValidation : AbstractValidator<Product>
  {
    public ProductValidation()
    {
      RuleFor(p => p.ProductName).NotEmpty().Length(2,20);
    }

  }
}
