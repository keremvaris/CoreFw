using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoreFw.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFw.Core.DataAccess.EntityFramework
{
  public partial class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
  {
    private readonly DbSet<TEntity> _entities;

    public EfEntityRepositoryBase(DbSet<TEntity> entities)
    {
      this._entities = entities;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
      using (var context = new TContext())
      {
        return context.Set<TEntity>().SingleOrDefault(filter);
      }
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
      using (var context = new TContext())
      {
        return filter == null
          ? context.Set<TEntity>().ToList()
          : context.Set<TEntity>().Where(filter).ToList();
      }
    }


    public IQueryable<TEntity> Table => this._entities;
    public IQueryable<TEntity> TableNoTracking => this._entities;

    public TEntity GetById(object id)
    {
      using (var context = new TContext())
      {
        return context.Set<TEntity>().Find(id);
      }
    }

    public void Add(TEntity entity)
    {
      using (var context = new TContext())
      {
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        context.SaveChanges();
      }
    }

    public void Add(IEnumerable<TEntity> entities)
    {
      using (var context = new TContext())
      {
        foreach (var entity in entities)
        {
          var addedEntity = context.Entry(entity);
          addedEntity.State = EntityState.Added;
        }
        context.SaveChanges();
      }
    }

    public void Update(TEntity entity)
    {
      using (var context = new TContext())
      {
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    public void Update(IEnumerable<TEntity> entities)
    {
      using (var context = new TContext())
      {
        foreach (var entity in entities)
        {
          var updatedEntity = context.Entry(entity);
          updatedEntity.State = EntityState.Modified;
        }
        context.SaveChanges();
      }
    }

    public void Delete(TEntity entity)
    {
      using (var context = new TContext())
      {
        var deleteEntity = context.Entry(entity);
        deleteEntity.State = EntityState.Deleted;
        context.SaveChanges();
      }
    }

    public void Delete(IEnumerable<TEntity> entities)
    {
      using (var context = new TContext())
      {
        foreach (var entity in entities)
        {
          var deletedEntity = context.Entry(entity);
          deletedEntity.State = EntityState.Deleted;
        }
        context.SaveChanges();
      }
    }

    public IEnumerable<TEntity> GetSql(string sql)
    {
      using (var context = new TContext())
      {
        var entity = context.Set<TEntity>();
        return entity.FromSql(sql);
      }
    }
  }
}
