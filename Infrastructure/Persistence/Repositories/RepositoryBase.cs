using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T>(DataBaseContext context) : IRepositoryBase<T> where T : EntityBase
    {
        public virtual bool Exists(int id)
        {
            return context.Set<T>().Find(id) is not null;
        }

        public virtual T? Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual bool Delete(int id)
        {
            var entity = Get(id);
            if (entity is null)
            {
                return false;
            }

            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return true;
        }
    }
}
