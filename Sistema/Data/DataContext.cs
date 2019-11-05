using Microsoft.EntityFrameworkCore;
using Sistema.Data.Entities;

namespace Sistema.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Operario> Operarios { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
