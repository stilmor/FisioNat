using System;
using System.Linq;
using Raist.Models;

namespace Raist.Data
{
    public static class DbInitializer
    {
        private static void Seed(ClinicaContext context) {

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

            //Alergeno
            var alergenos = new Alergeno[]
            {
               new Alergeno
                {
                    UUID = Guid.NewGuid(),
                    nombre = "almendra"
                },
                new Alergeno
                {
                    UUID = Guid.NewGuid(),
                    nombre = "piñon"
                },
            };
            foreach ( Alergeno a in alergenos)
            {
                context.Alergenos.Add(a);
            }


            //PACIENTE
            var pacientes = new Paciente[]
            {
                new Paciente
                {
                    UUID = Guid.NewGuid(),
                    codigoPin = 1234,
                    nombre = "victor",
                    apellido1 = "Fernandez",
                    apellido2 = "lopez",
                    telefonoFijo = 918876532,
                    telefonoMovil = 635988774,
                    fechaNacimiento = DateTime.Parse("11-02-1984"),
                    valoracionInicial = "Primera valoracion en consulta",
                    cirugia = "no tiene cirugias",
                    codigoPostal = 28845,
                    correoElectronico = "victorp@prueba.com"

                }
            };

            foreach (Paciente p in pacientes)
            {
                context.Pacientes.Add(p);
            }


            //PACIENTE DE CLINICA
            var pacientesdeclinicas = new PacienteDeClinica[]
            {
                new PacienteDeClinica
                {
                    clinica = clinicas[0],
                    paciente = pacientes[0]
                }
            };
            foreach(PacienteDeClinica pc in pacientesdeclinicas)
            {
                context.pacientesDeClinicas.Add(pc);
            }

            //TRATAMIENTO FARMACOLOLGICO

            var tratamientosfarmacologicos = new TratamientoFarmacologico[]
            {
                new TratamientoFarmacologico
                {
                    UUID = Guid.NewGuid(),
                    fechaInicio = new System.DateTime(2019,07,15,09,30,00),
                    fechaFin = new System.DateTime(2019,08,15,09,30,00),
                    descripcionTratamiento = "antiflamatorio",
                    paciente = pacientes[0]
                }
            };
            foreach(TratamientoFarmacologico tratamiento in tratamientosfarmacologicos)
            {
                context.tratamientosFarmacologicos.Add(tratamiento);
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

            //ESPECIALIDAD
            var especialidad = new Especialidad
                {
                    UUID = Guid.NewGuid(),
                    nombre = "Fisioterapia"
                };
            context.Add(especialidad);


            //ESPECIALISTA
            var especialistas = new Especialista[]
            {
                new Especialista
                {
                    UUID = Guid.NewGuid(),
                    empleado = empleado,
                    especialidad = especialidad,
                    numeroColegiado = 112
                }
            };
            foreach (Especialista espe in especialistas)
            {
                context.Especialistas.Add(espe);
            }

            //CITAS
            var citas = new Cita[]
            {
                new Cita{
                    UUID= Guid.Parse("1b2f1866-008d-46a4-8c98-2b16d6399213"),
                    horaCita = new System.DateTime(2019,08,30,17,30,00),
                    paciente = pacientes[0],
                    descripcionConsulta="Ver Peppa Pig",
                    especialista = especialistas[0]
                },
                new Cita{
                    UUID=Guid.NewGuid(),
                    horaCita = new System.DateTime(2019,09,30,17,30,00),
                    paciente = pacientes[0],
                    descripcionConsulta="Ver Superwings",
                    especialista = especialistas[0]
                }
            };
            foreach (Cita s in citas)
            {
                context.Citas.Add(s);
            }


            //TRATAMIENTOCITA
            var tratamientos = new TratamientoCita[]
            {
                new TratamientoCita
                {
                    UUID = Guid.NewGuid(),
                    fechaInicio = new System.DateTime(2019,08,30,17,30,00),
                    fechaFin = new System.DateTime(2019,09,05,17,30,00),
                    descripcion = "vendaje en la el hombro izquierdo",
                    cita = citas[0]
                }
            };

            foreach(TratamientoCita tr in tratamientos)
            {
                context.tratamientoCitas.Add(tr);
            }

             //Alergia
            context.Alergias.Add(
                new Alergia {
                    UUID = Guid.NewGuid(),
                    paciente = pacientes[0],
                    alergeno = alergenos[0],
                }
            );

            //REGISTRO
            context.registros.Add(
                new Registro {
                    usuario =  pacientes[0].correoElectronico,
                    password = pacientes[0].codigoPin.ToString(),
                    passwordHuella = "1234",
                    pacienteId = pacientes[0]
                }
            );

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
        }

        public static void Initialize(ClinicaContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Si esto esta aqui no ejecutamos nada.
            if (context.Citas.Any())
            {
                return;
            }

            Seed(context);
            context.SaveChanges();
        }
    }
}
