using System;
using System.Collections.Generic;
using System.Text;
using CoreFw.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreFw.Entities.Concrete
{
  public class Category:IEntity
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
  }
}
