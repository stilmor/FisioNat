using System;
using System.Linq;
using Raist.Models;


namespace Raist.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ClinicaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Citas.Any())
            {
                return;   // DB has been seeded
            }

            // CITAS
            var citas = new Cita[]
            {
                new Cita{
                    UUID=Guid.Parse("0b8670b5-63d4-4852-91b9-403d207c6e73"),especialidad="Fisioterapia",cuando=DateTime.Parse("2019-09-01"),
                    nombreEspecialista="Daniel Polo",descripcionConsulta="Ver Peppa Pig",tratamiento="Tratamiento con frio",
                    inicioTratamiento=DateTime.Parse("2019-09-03"), finTratamiento=DateTime.Parse("2019-10-01")
                },
                new Cita
                {
                    UUID = Guid.NewGuid(),
                    cuando = new System.DateTime(2019,08,30,17,30,00),
                    especialidad = "Podologia",
                    nombreEspecialista = "Isabel",
                    descripcionConsulta = "Acude a consulta por dolor en hombro izquierdo",
                    tratamiento = "manipulacion en la escapula del hombro izquierdo, tratamiento con frio y tens",
                    inicioTratamiento = new DateTime(2019,08,30),
                    finTratamiento = new DateTime(2019,09,5),
                }

            };
            foreach (Cita s in citas)
            {
                context.Citas.Add(s);
            }
            context.SaveChanges();

            //USUARIOS

            //ALERGENOS
        }
    }
}