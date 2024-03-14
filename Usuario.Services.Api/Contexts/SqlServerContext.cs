using Microsoft.EntityFrameworkCore;
using Usuario.Services.Api.Entities;

namespace Usuario.Services.Api.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasIndex(x=>x.Email)
                .IsUnique();
        }
        public DbSet<Pessoa> Usuarios { get; set; }
    }
}
