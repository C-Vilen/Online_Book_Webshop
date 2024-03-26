using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    // Inherits the .NET core DbContext class to query the database
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        // Creating categories table in the database
        public DbSet<Category> Categories { get; set; }
    }
}
