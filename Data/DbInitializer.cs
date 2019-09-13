using System;
using System.Linq;
using Raist.Models;

namespace Raist.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClinicaContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //CLINICAS

            var clinicas = new Clinica[]
            {
                new Clinica
                {
                    clinicaUUID = Guid.NewGuid(),
                    nombre = "Fisio Alcala",
                    calle = "Logrono",
                    numero = "5",
                    localidad = "Alcala de henares",
                    codigoPostal = 1234567899,
                    web = "probando.es",
                    telefono = 918846532

                }
            };
            foreach (Clinica u in clinicas)
            {
                context.Clinicas.Add(u);
            }
            context.SaveChanges();

            var pacientes = new Paciente[]
            {
                new Paciente
                {
                    pacienteUUID = Guid.Parse("984b0fe6-071e-416e-bfb2-f177ae7c8bdc"),
                    codigoPin = 1234,
                    nombre = "victor",
                    apellido1 = "Fernandez",
                    apellido2 = "lopez",
                    telefonoFijo = 918876532,
                    telefonoMovil = 635988774,
                    fechaNacimiento = DateTime.Parse("11-02-1984"),
                    valoracionInicial = "Primera valoracion en consulta",
                    cirugia = "no tiene cirugias",
                    codigoPostal = 28845
                }
            };

            foreach (Paciente p in pacientes)
            {
                context.Pacientes.Add(p);
            }
            context.SaveChanges();


            if (context.Citas.Any())
            {
                return;   // DB has been seeded
            }

            //EMPLEADO
               Empleado empleado = new Empleado
                   {
                       UUID = Guid.NewGuid(),
                       nombre = "Daniel",
                       apellido1 = "polo",
                       apellido2 = "takeuchi",

               };
               context.Add(empleado);
               context.SaveChanges();

            //ESPECIALIDAD
            var especialidad = new Especialidad
                {
                    UUID = Guid.NewGuid(),
                    nombre = "Fisioterapia"
                };
               context.Add(especialidad);
               context.SaveChanges();


            //ESPECIALISTA
            var especialistas = new Especialista[]
            {
                new Especialista
                {
                    UUID = Guid.NewGuid(),
                    empleadoId = empleado,
                    especialidadId = especialidad,
                    numeroColegiado = 112
                }
            };
            foreach (Especialista espe in especialistas)
            {
                context.Especialistas.Add(espe);
            }
            context.SaveChanges();

            //CITAS
            string nombre = especialistas[0].especialidadId.nombre;
            var citas = new Cita[]
            {
                new Cita{
                    UUID=Guid.Parse("0b8670b5-63d4-4852-91b9-403d207c6e73"),
                    fechaCita = DateTime.Parse("2019-09-01"),
                    horaCita = new System.DateTime(2019,08,30,17,30,00),
                    paciente = pacientes[0],
                    descripcionConsulta="Ver Peppa Pig",
                    especialista = especialistas[0],
                   // tratamiento="Tratamiento con frio",
                   // inicioTratamiento=DateTime.Parse("2019-09-03"),
                   // finTratamiento=DateTime.Parse("2019-10-01")
                }
            };
            foreach (Cita s in citas)
            {
                context.Citas.Add(s);
            }
            context.SaveChanges();

                // new Cita
                // {
                //     UUID = Guid.NewGuid(),
                //     pacienteUUID = Guid.NewGuid(),
                //     fechaCita = new System.DateTime(2019,08,30,17,30,00),
                    //especialidad = "Podologia",
                    // nombreEspecialista = "Isabel",
                    //descripcionConsulta = "Acude a consulta por dolor en hombro izquierdo",
                    //tratamiento = "manipulacion en la escapula del hombro izquierdo, tratamiento con frio y tens",
                    //inicioTratamiento = new DateTime(2019,08,30),
                    //finTratamiento = new DateTime(2019,09,5),
                //}
            //};
           /*  foreach (Cita s in citas)
            {
                context.Citas.Add(s);
            }
            context.SaveChanges();*/

            //USUARIOS


           /* var usuario = new Usuario []
            {
                new Usuario{
                    UUID =  Guid.NewGuid(),
                    nombre = "Raistlin",
                    apellido1 = "Majere",
                    apellido2 = "Majere",
                    telefono = "+34656355788",
                    email = "d&d.com",
                    codigoPin = 1234
                 }
            };
          /*  foreach (Usuario u in usuario)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();*/


            //ALERGENOS
        }
    }
}