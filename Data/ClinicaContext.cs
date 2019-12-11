using Raist.Models;
using Microsoft.EntityFrameworkCore;

namespace Raist.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options){}

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alergeno> Alergenos { get; set; }
        public DbSet<Alergia> Alergias { get; set; }
        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<Imagen> Imagenes {get; set;}
        public DbSet<Registro> registros {get; set;}
        public DbSet<TratamientoCita> tratamientoCitas{get; set;}
        public DbSet<TratamientoFarmacologico> tratamientosFarmacologicos {get; set;}
        public DbSet<Clinica> Clinicas {get; set;}
        public DbSet<PacienteDeClinica> pacientesDeClinicas {get; set;}
        public DbSet<Empleado> Empleados {get; set;}
        public DbSet<Especialidad> Especialidades {get; set;}

        public DbSet<Paciente> Pacientes {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registro>()
                .HasKey(c => new { c.usuario});

            modelBuilder.Entity<PacienteDeClinica>()
                .HasKey(a => new { a.pacienteUUID, a.clinicaUUID});

            modelBuilder.Entity<PacienteDeClinica>()
                .HasOne(pt => pt.clinica)
                .WithMany(p => p.pacienteDeClinicas)
                .HasForeignKey(pt => pt.clinicaUUID);

            modelBuilder.Entity<PacienteDeClinica>()
                .HasOne(pt => pt.paciente)
                .WithMany(p => p.pacienteDeClinicas)
                .HasForeignKey(pt => pt.pacienteUUID);
        }
    }
}
