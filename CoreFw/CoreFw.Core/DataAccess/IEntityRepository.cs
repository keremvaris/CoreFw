using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoreFw.Core.Entities;

namespace CoreFw.Core.DataAccess
{
  public interface IEntityRepository<T> where T : class, IEntity, new()
  {
    T Get(Expression<Func<T, bool>> filter = null);

    List<T> GetList(Expression<Func<T, bool>> filter = null);

    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
    T GetById(object id);

    void Add(T entity);
    void Add(IEnumerable<T> entities);
    void Update(T entity);
    void Update(IEnumerable<T> entities);
    void Delete(T entity);
    void Delete(IEnumerable<T> entities);
    IEnumerable<T> GetSql(string sql);
  }
}
