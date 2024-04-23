using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webshop.DataAccess.Data;
using Webshop.DataAccess.Repository.IRepository;

namespace Webshop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> Set;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.Set = _context.Set<T>();
        }
        public void Add(T entity)
        {
            Set.Add(entity);            
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> value = Set;
            return value.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> value = Set.Where(predicate);
            return value.FirstOrDefault();
        }
    }
}
