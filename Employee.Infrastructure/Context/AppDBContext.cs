

using Employee.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions <AppDBContext> options) : base(options)
        {

        }
        public DbSet<Employees> Employee { get; set; }
    }
}
