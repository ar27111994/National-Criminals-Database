using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    interface IRepository<TEntity> where TEntity:class
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void InsertOnSubmit(TEntity entity);
        void DeleteOnSubmit(TEntity entity);
    }
}
