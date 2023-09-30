using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        //IQueryable<T> AsQueryable<T>() where T : class;
        //IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class;
        //IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class;
        //IEnumerable<T> Get<T>() where T : class;
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int Entity);
        void Save();
    }
}
