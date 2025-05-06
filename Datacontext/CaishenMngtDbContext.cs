using CaishenManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using CaishenManagementAPI.Entity;

namespace CaishenManagementAPI.Datacontext
{
    public class CaishenMngtDbContext : DbContext
    {
        public CaishenMngtDbContext(DbContextOptions<CaishenMngtDbContext> options) : base(options) { }
        //
        public DbSet<Product> Products => Set<Product>();


    }
}
