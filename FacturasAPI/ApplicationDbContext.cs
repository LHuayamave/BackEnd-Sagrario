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
        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto).HasName("PK__Producto");

                entity.ToTable("Producto");

                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.EstadoProducto).IsRequired().HasMaxLength(1).IsUnicode(false).HasDefaultValue("A");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona).HasName("PK__Persona");
                entity.ToTable("Persona");
                entity.Property(e => e.Cedula).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Cedula).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.EstadoPersona).IsRequired().HasMaxLength(1).IsUnicode(false).HasDefaultValue("A");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");


            });

            modelBuilder.Entity<FacturaCabecera>(entity =>
            {
                entity.HasKey(e => e.IdFacturaCabecera).HasName("PK__FacturaCabecera");

                entity.ToTable("FacturaCabecera");

                entity.Property(e => e.FechaFacturaCreacion).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                entity.Property(e => e.EstadoFacturaCabecera).IsRequired().HasMaxLength(1).IsUnicode(false).HasDefaultValue("A");
                entity.Property(e => e.NumeroFactura).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
                entity.Property(e => e.NombreCliente).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.NombreEmpresa).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.DireccionEmpresa).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.TelefonoEmpresa).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");


                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.FacturaCabecera)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaCabecera_Persona");
            });


            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalle).HasName("PK__FacturaDetalle");

                entity.ToTable("FacturaDetalle");

                entity.Property(e => e.Cantidad).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.PrecioUnitario).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.SubtotalProducto).IsRequired().HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.FacturaCabecera)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdFacturaCabecera)
                    .HasConstraintName("FK_FacturaDetalle_FacturaCabecera");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaDetalle_Producto");
            });
        }
    }
}
