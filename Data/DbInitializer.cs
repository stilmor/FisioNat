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
                sexo = "Hombre",
                apellido1 = "Fernandez",
                apellido2 = "lopez",
                telefonoFijo = 918876532,
                telefonoMovil = 635988774,
                fechaNacimiento = DateTime.Parse ("11-02-1984"),
                valoracionInicial = "Primera valoracion en consulta",
                cirugia = "no tiene cirugias",
                codigoPostal = 28845,
                correoElectronico = "victorp@prueba.com",
                historial = "Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio. Tiene sus raices en una pieza cl´sica de la literatura del Latin, que data del año 45 antes de Cristo, haciendo que este adquiera mas de 2000 años de antiguedad. Richard McClintock, un profesor de Latin de la Universidad de Hampden-Sydney en Virginia, encontró una de las palabras más oscuras de la lengua del latín, consecteur, en un pasaje de Lorem Ipsum, y al seguir leyendo distintos textos del latín, descubrió la fuente indudable. Lorem Ipsum viene de las secciones 1.10.32 y 1.10.33 de de Finnibus Bonorum et Malorum (Los Extremos del Bien y El Mal) por Cicero, escrito en el año 45 antes de Cristo. Este libro es un tratado de teoría de éticas, muy popular durante el Renacimiento. La primera linea del Lorem Ipsum, Lorem ipsum dolor sit amet.., viene de una linea en la sección 1.10.32"

                },
                new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "Miliki",
                sexo = "Hombre",
                apellido1 = "Loeches",
                apellido2 = "Gomez",
                telefonoFijo = 918863254,
                telefonoMovil = 636788544,
                fechaNacimiento = DateTime.Parse ("06-09-2000"),
                provincia = "Madrid",
                codigoPostal = 28803,
                correoElectronico = "tutumi@gmail.com",
                historial = "primera cita, se le realiza primera palpacion de zona afectada en costado derecho"
                },
                new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "Maria",
                sexo = "Mujer",
                apellido1 = "Alonso",
                apellido2 = "jimenez",
                telefonoFijo = 918866399,
                telefonoMovil = 626794544,
                fechaNacimiento = DateTime.Parse ("12-11-1994"),
                provincia = "Madrid",
                codigoPostal = 28803,
                correoElectronico = "sauron@gmail.com"
                },
                new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = "Vera",
                sexo = "Mujer",
                apellido1 = "Martin",
                apellido2 = "Martin",
                telefonoFijo = 918845387,
                telefonoMovil = 752794566,
                ocupacion = "Estudiante",
                actividadFisica = "Baloncesto",
                valoracionInicial = "posible lesion en rodilla izquierda",
                cirugia = "cirugia 'apendicitis'",
                calle = "Gomez de ochoa",
                portal = "5",
                escalera = "izq",
                piso = "5",
                letra = "B",
                poblacion = "Alcala de henares",
                provincia = "Madrid",
                fechaNacimiento = DateTime.Parse ("03-09-1997"),
                codigoPostal = 28805,
                correoElectronico = "tutututu@gmail.com",
                historial = "consulta sobre dolor al caminar en rodilla izquierda"
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
                rol = "especialista",
                nombre = "Daniel",
                sexo = "Hombre",
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
                        password = "1234", //pacientes[0].codigoPin.ToString (),
                        passwordHuella = "1234",
                        pacienteId = pacientes[0]
                }
            );

            //Imagenes
            //https://fisionatbucket.s3-us-west-2.amazonaws.com/1215d448-3023-48e2-9a18-982c9a262914starwars.png

            // var pacientes = new Paciente[] {
            //     new Paciente {

            var imagenes = new Imagen[] {
                new Imagen {
                    url = "https://fisionatbucket.s3-us-west-2.amazonaws.com/2702cb04-3f39-4684-8125-8f81056971fa450_1000.jpg",
                        paciente = pacientes[0],
                        descripcion = "imagen de prueba"
                },
                new Imagen {
                    url = "https://fisionatbucket.s3-us-west-2.amazonaws.com/1215d448-3023-48e2-9a18-982c9a262914starwars.png",
                        paciente = pacientes[0],
                        descripcion = "imagen de prueba 2"
                }
            };

            foreach (Imagen p in imagenes) {
                context.Imagenes.Add (p);
            }

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