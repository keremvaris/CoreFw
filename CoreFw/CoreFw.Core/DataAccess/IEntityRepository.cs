using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoreFw.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFw.Core.DataAccess
{
  public interface IEntityRepository<T>
    where T : class, IEntity, new()
  {
    T Get(Expression<Func<T, bool>> filter);
    IList<T> GetList(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
  } 
}
