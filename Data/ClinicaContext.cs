using Raist.Models;
using Microsoft.EntityFrameworkCore;

namespace Raist.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
        }
         public DbSet<Cita> Citas { get; set; }
         public DbSet<Usuario> Usuarios { get; set; }
          public DbSet<Alergeno> Alergenos { get; set; }
          public DbSet<Especialista> Especialistas { get; set; }

          public  DbSet<Imagen> Imagenes{get; set;}

    }
}
