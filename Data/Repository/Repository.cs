using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
       
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            entities.Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            context.SaveChanges();
        }

        public void Delete(int entity)
        {
            if (entity == 0)
            {
                throw new ArgumentNullException("entity");
            }
            T existing = entities.Find(entity);
            entities.Remove(existing);
            context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
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
