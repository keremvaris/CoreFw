using System;
using System.Collections.Generic;
using System.Text;
using CoreFw.Business.Abstract;
using CoreFw.DataAccess.Abstract;

namespace CoreFw.Business.Concrete
{
  public class CategoryManager:ICategoryService
  {
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
      _categoryDal = categoryDal;
    }
  }
}
