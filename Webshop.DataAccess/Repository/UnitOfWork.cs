using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webshop.DataAccess.Data;
using Webshop.DataAccess.Repository.IRepository;

namespace Webshop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    { 
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
