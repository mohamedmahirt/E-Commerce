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
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<bool> Insert(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(int Entity);
    }
}
