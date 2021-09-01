using Microsoft.EntityFrameworkCore;

namespace PocketApi.Models
{
    public class PocketContext : DbContext
    {
        public PocketContext(DbContextOptions<PocketContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Adelanto> Adelantos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Tipo_Empleado> Tipos_Empleado { get; set; }
    }
}
