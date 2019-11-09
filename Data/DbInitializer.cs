using System;
using System.Linq;
using Raist.Models;

namespace Raist.Data {
    public static class DbInitializer {
        private static void Seed (ClinicaContext context) {

            //CLINICAS
            var clinicas = new Clinica[] {
                new Clinica {
                clinicaUUID = Guid.NewGuid (),
                nombre = "Fisio Alcala",
                calle = "Logrono",
                numero = "5",
                localidad = "Alcala de henares",
                codigoPostal = 28804,
                web = "probando.es",
                telefono = 918846532

                },
                new Clinica {
                clinicaUUID = Guid.NewGuid (),
                nombre = "FisioDeporte",
                calle = " Vitoria",
                numero = "3",
                localidad = "Alcala de henares",
                codigoPostal = 28804,
                web = "https://iesavellaneda.es/",
                telefono = 918881174

                },
                new Clinica {
                clinicaUUID = Guid.NewGuid (),
                nombre = "FisioUah",
                calle = "Av. de Madrid Campus Universitario",
                numero = "19",
                localidad = "Alcala de henares",
                codigoPostal = 28871,
                web = "http://medicinaycienciasdelasalud.uah.es/inicio.asp?seccion=fisioterapia",
                telefono = 918854505
                }
            };
            foreach (Clinica u in clinicas) {
                context.Clinicas.Add (u);
            }

            //Alergeno
            var alergenos = new Alergeno[] {
                new Alergeno {
                UUID = Guid.NewGuid (),
                nombre = "almendra"
                },
                new Alergeno {
                UUID = Guid.NewGuid (),
                nombre = "piñon"
                },
            };
            foreach (Alergeno a in alergenos) {
                context.Alergenos.Add (a);
            }

            //PACIENTE
            var pacientes = new Paciente[] {
                new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "victor",
                apellido1 = "Fernandez",
                apellido2 = "lopez",
                telefonoFijo = 918876532,
                telefonoMovil = 635988774,
                fechaNacimiento = DateTime.Parse ("11-02-1984"),
                valoracionInicial = "Primera valoracion en consulta",
                cirugia = "no tiene cirugias",
                codigoPostal = 28845,
                correoElectronico = "victorp@prueba.com"

                },
                new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "Miliki",
                apellido1 = "Loeches",
                apellido2 = "Gomez",
                telefonoFijo = 918863254,
                telefonoMovil = 636788544,
                fechaNacimiento = DateTime.Parse ("06-09-2000"),
                provincia = "Madrid",
                codigoPostal = 28803,
                correoElectronico = "tutumi@gmail.com"
                },
                  new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "Maria",
                apellido1 = "Alonso",
                apellido2 = "jimenez",
                telefonoFijo = 918866399,
                telefonoMovil = 626794544,
                fechaNacimiento = DateTime.Parse ("12-11-1994"),
                provincia = "Madrid",
                codigoPostal = 28803,
                correoElectronico = "sauron@gmail.com"
                }
            };

            foreach (Paciente p in pacientes) {
                context.Pacientes.Add (p);
            }

            //PACIENTE DE CLINICA
            var pacientesdeclinicas = new PacienteDeClinica[] {
                new PacienteDeClinica {
                clinica = clinicas[0],
                paciente = pacientes[0]
                }
            };
            foreach (PacienteDeClinica pc in pacientesdeclinicas) {
                context.pacientesDeClinicas.Add (pc);
            }

            //TRATAMIENTO FARMACOLOLGICO

            var tratamientosfarmacologicos = new TratamientoFarmacologico[] {
                new TratamientoFarmacologico {
                UUID = Guid.NewGuid (),
                fechaInicio = new System.DateTime (2019, 07, 15, 09, 30, 00),
                fechaFin = new System.DateTime (2019, 08, 15, 09, 30, 00),
                descripcionTratamiento = "antiflamatorio",
                paciente = pacientes[0]
                }
            };
            foreach (TratamientoFarmacologico tratamiento in tratamientosfarmacologicos) {
                context.tratamientosFarmacologicos.Add (tratamiento);
            }

            //EMPLEADO
            Empleado empleado = new Empleado {
                UUID = Guid.NewGuid (),
                nombre = "Daniel",
                apellido1 = "polo",
                apellido2 = "takeuchi",

            };
            context.Add (empleado);

            //ESPECIALIDAD
            var especialidad = new Especialidad {
                UUID = Guid.NewGuid (),
                nombre = "Fisioterapia"
            };
            context.Add (especialidad);

            //ESPECIALISTA
            var especialistas = new Especialista[] {
                new Especialista {
                UUID = Guid.NewGuid (),
                empleado = empleado,
                especialidad = especialidad,
                numeroColegiado = 112
                }
            };
            foreach (Especialista espe in especialistas) {
                context.Especialistas.Add (espe);
            }

            //CITAS
            var citas = new Cita[] {
                new Cita {
                UUID = Guid.NewGuid (),
                id = 1,
                horaCita = new System.DateTime (2019, 08, 30, 17, 30, 00),
                paciente = pacientes[0],
                descripcionConsulta = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proidentsunt in culpa qui officia deserunt mollit anim id est laborum",
                especialista = especialistas[0]
                },
                new Cita {
                UUID = Guid.NewGuid (),
                id = 2,
                horaCita = new System.DateTime (2019, 09, 30, 17, 30, 00),
                paciente = pacientes[0],
                descripcionConsulta = "Ver Superwings",
                especialista = especialistas[0]
                }
            };
            foreach (Cita s in citas) {
                context.Citas.Add (s);
            }

            //TRATAMIENTOCITA
            var tratamientos = new TratamientoCita[] {
                new TratamientoCita {
                UUID = Guid.NewGuid (),
                fechaInicio = new System.DateTime (2019, 08, 30, 17, 30, 00),
                fechaFin = new System.DateTime (2019, 09, 05, 17, 30, 00),
                descripcion = "vendaje en la el hombro izquierdo",
                cita = citas[0]
                }
            };

            foreach (TratamientoCita tr in tratamientos) {
                context.tratamientoCitas.Add (tr);
            }

            //Alergia
            context.Alergias.Add (
                new Alergia {
                    UUID = Guid.NewGuid (),
                        paciente = pacientes[0],
                        alergeno = alergenos[0],
                }
            );

            //REGISTRO
            context.registros.Add (
                new Registro {
                    usuario = pacientes[0].correoElectronico,
                        password = pacientes[0].codigoPin.ToString (),
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

        public static void Initialize (ClinicaContext context) {
            context.Database.EnsureDeleted ();
            context.Database.EnsureCreated ();

            // Si esto esta aqui no ejecutamos nada.
            if (context.Citas.Any ()) {
                return;
            }

            Seed (context);
            context.SaveChanges ();
        }
    }
}