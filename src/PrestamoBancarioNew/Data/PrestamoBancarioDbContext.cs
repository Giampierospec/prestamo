using Microsoft.EntityFrameworkCore;
using PrestamoBancarioNew.Models;

namespace PrestamoBancarioNew.Data
{
    public class PrestamoBancarioDbContext : DbContext
    {
        public PrestamoBancarioDbContext(DbContextOptions<PrestamoBancarioDbContext> options): base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<InfoPrestamo> InfoPrestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<InfoPrestamo>().ToTable("InfoPrestamo");
        }
    }
}
