using Microsoft.EntityFrameworkCore;

namespace examen_reposicion.Models
{
    public class VehiculoDbContext : DbContext
    {
        public VehiculoDbContext() { }
        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options) : base(options) { }

        public DbSet<Vehiculo> tbl_vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehiculo>().HasKey(v => v.idVehiculo);

        }
    }

}