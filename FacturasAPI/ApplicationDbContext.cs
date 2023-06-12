using FacturasAPI.Entidad;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<FacturaCabecera> FacturasCabecera { get; set; }
        public DbSet<FacturaDetalle> FacturasDetalle { get; set; }
        public DbSet<FacturaDetalleProducto> FacturasDetalleProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacturaCabecera>()
                .HasOne(fc => fc.FacturaDetalle)
                .WithOne(fd => fd.FacturaCabecera)
                .HasForeignKey<FacturaDetalle>(fd => fd.Id);

            modelBuilder.Entity<FacturaDetalleProducto>()
                .HasKey(fdp => new { fdp.FacturaDetalleId, fdp.ProductoId });

            modelBuilder.Entity<FacturaDetalleProducto>()
                .HasOne(fdp => fdp.FacturaDetalle)
                .WithMany(fd => fd.FacturaDetalleProductos)
                .HasForeignKey(fdp => fdp.FacturaDetalleId);

            modelBuilder.Entity<FacturaDetalleProducto>()
                .HasOne(fdp => fdp.Producto)
                .WithMany(p => p.FacturaDetalleProductos)
                .HasForeignKey(fdp => fdp.ProductoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
