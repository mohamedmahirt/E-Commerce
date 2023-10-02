using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Shopbridge_Context context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(Shopbridge_Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
       
        public async Task<List<T>> GetAll()
        {
            return  await this.entities.ToListAsync();
        }

        public async Task<bool> Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            entities.Add(obj);
            var count = await this.context.SaveChangesAsync();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Update(T obj)
        {
            if (obj == null)
            {
                return false;
            }
            entities.Update(obj);
            var count = await this.context.SaveChangesAsync();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int entity)
        {
            if (entity == 0)
            {
                throw new ArgumentNullException("entity");
            }
            T existing = await entities.FindAsync(entity);
            entities.Remove(existing);
            var count= await this.context.SaveChangesAsync();
            if (count > 0)
            {
                return false;
            }
            return true;
        }
        public async Task<T> GetById(object id)
        {
            return await this.entities.FindAsync(id);
        }

        //public IQueryable<T> AsQueryable<T>() where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> Get<T>() where T : class
        //{
        //    throw new NotImplementedException();
        //}
    }
}
