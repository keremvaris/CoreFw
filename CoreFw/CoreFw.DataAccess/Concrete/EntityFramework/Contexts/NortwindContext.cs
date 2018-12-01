using System;
using System.Collections.Generic;
using System.Text;
using CoreFw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreFw.DataAccess.Concrete.EntityFramework.Contexts
{
  public class NortwindContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=NEPTUN\DVLP2008;Database=Northwind;Trusted_Connection=true");
    }

    public virtual DbSet<Product> Products { get; set; }
    
  }
}
