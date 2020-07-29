using BackOffice.Model;
using Microsoft.EntityFrameworkCore;

namespace BackOffice
{
    public class BackOfficeDBContext : DbContext
    {
        public BackOfficeDBContext(DbContextOptions<BackOfficeDBContext> options) : base(options) { }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}