using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly DataContext database;
        public Repository(NCDDataContext dataContext)
        {
            database = dataContext;
        }
        public virtual TEntity GetById(int id)
        {
            var itemParameter = Expression.Parameter(typeof(TEntity), "item");
            var whereExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                        GetPrimaryKeyName<TEntity>()
                        ),
                    Expression.Constant(id)
                    ),
                new[] { itemParameter }
                );
            return GetAll().AsQueryable().Where(whereExpression).Single();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return database.GetTable<TEntity>();
        }
        public virtual void InsertOnSubmit(TEntity entity)
        {
            GetTable().InsertOnSubmit(entity);
        }
        public virtual void DeleteOnSubmit(TEntity entity)
        {
            GetTable().DeleteOnSubmit(entity);
        }
        public virtual ITable GetTable()
        {
            return database.GetTable<TEntity>();
        }
        public string GetPrimaryKeyName<T>()
        {
            var type = database.Mapping.GetMetaType(typeof(T));

            var PK = (from m in type.DataMembers
                      where m.IsPrimaryKey
                      select m).Single();
            return PK.Name;
        }
    }
}
