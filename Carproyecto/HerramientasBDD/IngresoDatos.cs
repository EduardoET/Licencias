using Microsoft.EntityFrameworkCore;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Carproyecto.HerramientasBDD
{
    public class IngresoDatos
    {
        // Crear toda la base inicial
        static public void CrearBDEscenario1()
        {
            IngresoDatos datos = new IngresoDatos();
            var escenario1 = datos.Escenario1();
            datos.Guarda(escenario1);
        }

        // Borrado de todas las matrículas
        static public void BorrarMatrículas()
        {
            // Borra las matrículas de la base
            using (var context = new Realacion(CarBDD.DBConn()))
            {
                // Borra los detalles
        
                // Borra las cabeceras
                var lstMatrParaBorrar = context.matriculas.ToList();
                context.matriculas.RemoveRange(lstMatrParaBorrar);

                context.SaveChanges();
            }
        }

        static public void InsertaMatriculasPedroJoseMaria()
        {
            // Matriculas de Stalin
          
            string ApsNombre = "Stalin Dominguez";
            
            string tipNombre = "Licencia Tipo A";

            // Matrícula de segundo nivel
            int periodoId = 1;
            string[] Nivel2cursosNombres = new string[] { "NIVEL 2 Diurna Licencia Tipo B" };
            Matricula moduloStalinNivel2 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel2cursosNombres);
            Console.WriteLine(" Matricula Id: " + moduloStalinNivel2.MatriculaId);

            // Matrícula de tercer nivel
            
            periodoId = 2;
            string[] Nivel3cursosNombres = new string[] { "Nivel 3 Nortuna Licencia Tipo C" };
            Matricula moduloStalinNivel3 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel3cursosNombres);
            Console.WriteLine(" Matricula Id: " + moduloStalinNivel3.MatriculaId);

            // Matrícula de cuarto nivel
            periodoId = 3;
            string[] Nivel4cursosNombres = new string[] { "Nivel 4 Diurno Licencia Tipo E", "Nivel 4 Licencia Tipo F" };
            Matricula matrPedroNivel4 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel4cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrPedroNivel4.MatriculaId);

            // Registro de Notas de Stalin ejem
            // Notas de segundo Nivel
            notas califStalinNivel2tipoB = new notas() { Nota1 = 5.55f, Nota2 = 4.34f, Nota3 = 5.74f, Nota4 = 2.25f };
            notas califPedroNivel2AdminDB = new notas() { Nota1 = 8.78f, Nota2 = 7.12f, Nota3 = 6.25f, Nota4 = 3.74f };
            Dictionary<string, notas> dicPedroCursosCalifsNivel2 = new Dictionary<string, notas>();
            dicPedroCursosCalifsNivel2.Add("Nivel 1 LICENCIA Tipo B", califStalinNivel2tipoB);
            dicPedroCursosCalifsNivel2.Add("Nivel 2 Diurno de Administración BBDD", califPedroNivel2AdminDB);
            RegistrarNotas(moduloStalinNivel2.MatriculaId, dicPedroCursosCalifsNivel2);
            // Notas de tercer Nivel
            notas califPedroNivel3LogProg = new notas() { Nota1 = 6.65f, Nota2 = 8.94f, Nota3 = 9.74f };
            notas califPedroNivel3ProdDig = new notas() { Nota1 = 7.84f, Nota2 = 9.12f, Nota3 = 8.50f };
            notas califPedroNivel3VideoMk = new notas() { Nota1 = 4.84f, Nota2 = 5.12f, Nota3 = 8.50f };
            Dictionary<string, notas> dicPedroCursosCalifsNivel3 = new Dictionary<string, notas>();
            dicPedroCursosCalifsNivel3.Add("Nivel 3 Diurno de Lógica de Programación", califPedroNivel3LogProg);
            dicPedroCursosCalifsNivel3.Add("Nivel 3 Diurno de Productos Digitales", califPedroNivel3ProdDig);
            dicPedroCursosCalifsNivel3.Add("Nivel 3 Diurno de Video Marketing", califPedroNivel3VideoMk);
            RegistrarNotas(moduloStalinNivel3.MatriculaId, dicPedroCursosCalifsNivel3);

            //Reporte
            ReporteNota.CalificacionesPorAspirante(ApsNombre);

            // Matriculas de Maria
            ApsNombre = "María Blanco";
            // Matrícula de segundo nivel
            periodoId = 1;
            Nivel2cursosNombres = new string[] { "Nivel 2 Diurna de Diseño Web", "Nivel 2 Diurno de Administración BBDD" };
            Matricula matrMariaNivel2 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel2cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrMariaNivel2.MatriculaId);

            // Matrícula de tercer nivel
            periodoId = 2;
            Nivel3cursosNombres = new string[] { "Nivel 3 Diurno de Lógica de Programación", "Nivel 3 Diurno de Video Marketing" };
            Matricula matrMariaNivel3 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel3cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrMariaNivel3.MatriculaId);

            // Matrícula de cuarto nivel
            periodoId = 3;
            Nivel4cursosNombres = new string[] { "Nivel 4 Diurno de Programación Web", "Nivel 4 Diurno de E-Learning" };
            Matricula matrMariaNivel4 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel4cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrMariaNivel4.MatriculaId);

            // Registro de Notas de Maria
            // Notas de segundo Nivel
            notas califMariaNivel2Disenio = new notas() { Nota1 = 7.02f, Nota2 = 7.24f, Nota3 = 6.69f };
            notas califMariaNivel2AdminDB = new notas() { Nota1 = 7.48f, Nota2 = 6.42f, Nota3 = 8.27f };
            Dictionary<string, notas> dicMariaCursosCalifsNivel2 = new Dictionary<string, notas>();
            dicMariaCursosCalifsNivel2.Add("Nivel 2 Diurna de Diseño Web", califMariaNivel2Disenio);
            dicMariaCursosCalifsNivel2.Add("Nivel 2 Diurno de Administración BBDD", califMariaNivel2AdminDB);
            RegistrarNotas(matrMariaNivel2.MatriculaId, dicMariaCursosCalifsNivel2);
            // Notas de tercer Nivel
            notas califMariaNivel3LogProg = new notas() { Nota1 = 9.12f, Nota2 = 7.33f, Nota3 = 7.25f };
            notas califMariaNivel3VideoMk = new notas() { Nota1 = 7.84f, Nota2 = 7.12f, Nota3 = 8.50f };
            Dictionary<string, notas> dicMariaCursosCalifsNivel3 = new Dictionary<string, notas>();
            dicMariaCursosCalifsNivel3.Add("Nivel 3 Diurno de Lógica de Programación", califMariaNivel3LogProg);
            dicMariaCursosCalifsNivel3.Add("Nivel 3 Diurno de Video Marketing", califMariaNivel3VideoMk);
            RegistrarNotas(matrMariaNivel3.MatriculaId, dicMariaCursosCalifsNivel3);

            //Reporte
            ReporteNota.CalificacionesPorAspirante(ApsNombre);

            // Matriculas de Juan
            ApsNombre = "Juan Mera";

            // Matrícula de segundo nivel
            periodoId = 1;
            Nivel2cursosNombres = new string[] { "Nivel 2 Diurna de Diseño Web", "Nivel 2 Diurno de Administración BBDD" };
            Matricula matrJuanNivel2 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel2cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrJuanNivel2.MatriculaId);

            // Matrícula de tercer nivel
            periodoId = 2;
            Nivel3cursosNombres = new string[] { "Nivel 3 Diurno de Lógica de Programación", "Nivel 3 Diurno de Productos Digitales", "Nivel 3 Diurno de Video Marketing" };
            Matricula matrJuanNivel3 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel3cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrJuanNivel3.MatriculaId);

            // Matrícula de cuarto nivel
            periodoId = 3;
            Nivel4cursosNombres = new string[] { "Nivel 4 Diurno de Programación Web", "Nivel 4 Diurno de E-Learning" };
            Matricula matrJuanNivel4 = CreaMatricula(ApsNombre, tipNombre, periodoId, Nivel4cursosNombres);
            Console.WriteLine(" Matricula Id: " + matrJuanNivel4.MatriculaId);

            // Registro de Notas de Juan
            // Notas de segundo Nivel
            notas califJuanNivel2Disenio = new notas() { Nota1 = 8.55f, Nota2 = 8.34f, Nota3 = 8.74f };
            notas califJuanNivel2AdminDB = new notas() { Nota1 = 8.78f, Nota2 = 9.33f, Nota3 = 6.27f };
            Dictionary<string, notas> dicJuanCursosCalifsNivel2 = new Dictionary<string, notas>();
            dicJuanCursosCalifsNivel2.Add("Nivel 2 Diurna de Diseño Web", califJuanNivel2Disenio);
            dicJuanCursosCalifsNivel2.Add("Nivel 2 Diurno de Administración BBDD", califJuanNivel2AdminDB);
            RegistrarNotas(matrJuanNivel2.MatriculaId, dicJuanCursosCalifsNivel2);
            // Notas de tercer Nivel
            notas califJuanNivel3LogProg = new notas() { Nota1 = 6.89f, Nota2 = 6.82f, Nota3 = 7.34f };
            notas califJuanNivel3ProdDig = new notas() { Nota1 = 7.84f, Nota2 = 4.12f, Nota3 = 5.50f };
            notas califJuanNivel3VideoMk = new notas() { Nota1 = 9.84f, Nota2 = 8.12f, Nota3 = 7.37f };
            Dictionary<string, notas> dicJuanCursosCalifsNivel3 = new Dictionary<string, notas>();
            dicJuanCursosCalifsNivel3.Add("Nivel 3 Diurno de Lógica de Programación", califJuanNivel3LogProg);
            dicJuanCursosCalifsNivel3.Add("Nivel 3 Diurno de Productos Digitales", califJuanNivel3ProdDig);
            dicJuanCursosCalifsNivel3.Add("Nivel 3 Diurno de Video Marketing", califJuanNivel3VideoMk);
            RegistrarNotas(matrJuanNivel3.MatriculaId, dicJuanCursosCalifsNivel3);

            //Reporte
            ReporteNota.CalificacionesPorAspirante(ApsNombre);
        }

        // Registro de una matrícula
        static public Matricula CreaMatricula(
            string aspNombre, string tipNombre, int periodoId, string[] cursosNombres)
        {
            using (var context = new Realacion(CarBDD.DBConn()))
            {
                // 1.- Consulta del estudiante
                Aspirante aspirante = context.aspirantes
                    .Single(est => est.NombreASP == aspNombre);
                Console.WriteLine(aspirante.AspiranteID + " " + aspirante.NombreASP);
                // 2.- Consulta de la carrera
                tipo tipo = context.tipos
                    .Single(tip => tip.NombreTipo == tipNombre);
                Console.WriteLine(tipo.TipoId + " " + tipo.NombreTipo);
                // 3.- Consulta del período
                Periodo periodo = context.periodos
                    .Single(periodo => periodo.PeriodoId == periodoId);
                Console.WriteLine(
                    "{0}   {1:yyyy/MM/dd}  {2:yyyy/MM/dd}",
                    periodo.PeriodoId, periodo.FechaInicio, periodo.FechaFin);
                // 4.- Cabecera de Matrícula
                Matricula matricula = new Matricula()
                {
                    Aspirante = aspirante,
                    Fecha = new DateTime(2020, 10, 15),
                    tipo = tipo,
                    Estado = "Pendiente",
                    Periodo = periodo
                };
                Console.WriteLine("--> Matricula ID: " + matricula.MatriculaId);
                // 5.- Detalles de la Matrícula
               
                // 6.- Guardar todos los cambios
                context.matriculas.Add(matricula);
                context.SaveChanges();
                return matricula;
            }
        }

        // Registrar las calificaciones de un estudiante
        static public void RegistrarNotas(int matrEstudianteId, Dictionary<string, notas> dicCursosCalifs)
        {
            using (var context = new Realacion(CarBDD.DBConn()))
            {
               
                // Buscar el curso
                
                {
                    
                }
                // Guardar
              
            }
        }

        //
        public void Guarda(Dictionary<string, object> DB)
        {
            // Recupera las listas básicas
            List<Aspirante> lstAspirante = (List<Aspirante>)DB["lstAspirante"];
            //List<tipo> lstTipo = (List<tipo>)DB["lstTipo"];
            List<Modulos> lstModulos = (List<Modulos>)DB["lstModulos"];
            List<Periodo> lstPeriodos = (List<Periodo>)DB["lstPeriodos"];
            List<Curso> lstCursos = (List<Curso>)DB["lstCursos"];
            Config configuracion = (Config)DB["Configuracion"];
            // Guarda la información
            using (var context = new Realacion(CarBDD.DBConn()))
            {
                // Se asegura que la base de datos es borrada y vuelta a crear
                Console.WriteLine(" [1] Borrado de la base de datos ...");
                context.Database.EnsureDeleted();
                Console.WriteLine(" [2] Creación de la base de datos ...");
                context.Database.EnsureCreated();
                // Alimenta de datos
                context.aspirantes.AddRange(lstAspirante);
                //context.tipos.AddRange(lstTipo);
                context.modulos.AddRange(lstModulos);
                context.periodos.AddRange(lstPeriodos);
                context.cursos.AddRange(lstCursos);
                context.configs.Add(configuracion);
                // Grabar los datos iniciales
                Console.WriteLine(" [3] Carga de datos iniciales ...");
                context.SaveChanges();
            }
        }

        // Escenario 1: Pedro, Juan y María
        public Dictionary<string, Object> Escenario1()
        {
            Dictionary<string, Object> resultado = new Dictionary<string, object>();

            // Carga inicial de datos 
            // 0.- Configuración
            Config configuracion = new Config()
            {
                CreditosMaximo = 24,
                AgenciaNombre = "CAR PROFESINAL ",
                PesoNota1 = 0.30f,
                PesoNota2 = 0.30f,
                PesoNota3 = 0.30f,
                PesoNota4 = 0.40f,
                NotaMinima = 7.00f
            };
            // 1.- Estudiante
            Aspirante aspStalin = new Aspirante() { NombreASP = "Stalin Dominguez" };
            Aspirante aspLeonardo = new Aspirante() { NombreASP = "Leonardo Chavez" };
            Aspirante aspFernanda = new Aspirante() { NombreASP = "Fernanda Ortiz" };
            List<Aspirante> lstAspirante = new List<Aspirante>()
            {
                aspStalin, aspLeonardo, aspFernanda
            };
            // --------------------------------------------------
            resultado.Add("lstAspirante", lstAspirante);
            // --------------------------------------------------

            // 2.- Períodos
            Periodo per2020_PAO2 = new Periodo()
            {
                Estado = "Abierto",
                FechaInicio = new DateTime(2020, 9, 1),
                FechaFin = new DateTime(2021, 3, 1)
            };
            Periodo per2021_PAO1 = new Periodo()
            {
                Estado = "Abierto",
                FechaInicio = new DateTime(2021, 4, 1),
                FechaFin = new DateTime(2021, 9, 1)
            };
            Periodo per2021_PAO2 = new Periodo()
            {
                Estado = "Abierto",
                FechaInicio = new DateTime(2021, 9, 1),
                FechaFin = new DateTime(2022, 3, 1)
            };
            List<Periodo> lstPeriodos = new List<Periodo>()
            {
                per2020_PAO2, per2021_PAO1, per2021_PAO2
            };

            // --------------------------------------------------
            resultado.Add("lstPeriodos", lstPeriodos);
            // --------------------------------------------------

            // 3.- Tipos licencias
            tipo tiplicenciaC = new tipo()
            {
                NombreTipo = "Licencia Tipo B",
                CostoCredito = 34.50f
            };
            tipo tiplicenciaF = new tipo()
            {
                NombreTipo = "Licencia Tipo B",
                CostoCredito = 34.50f
            };
            tipo tiplicenciaG = new tipo()
            {
                NombreTipo = "Licencia Tipo B",
                CostoCredito = 34.50f
            };
            tipo tiplicenciaB = new tipo()
            {
                NombreTipo = "Licencia Tipo B",
                CostoCredito = 35.12f
            };
            List<tipo> lstCarreras = new List<tipo>() { tiplicenciaB, tiplicenciaC, tiplicenciaF, tiplicenciaG };

            // --------------------------------------------------
            resultado.Add("lstCarreras", lstCarreras);
            // --------------------------------------------------

            // 4.- Materias
            Modulos modAdminDB = new Modulos()
            {
                Area = "Tutoriales",
                Creditos = 3,
                Nombre = "Licencia Tipo B"
            };
            Modulos modVideoMk = new Modulos() { Nombre = "Educación Vial", Area = "Tutoriales", Creditos = 3 };
            Modulos modDisenio = new Modulos() { Nombre = "Ley reglamento de Transporte terrestre Transito y Seguridad Vial	", Area = "Tutoriales", Creditos = 3 };
            Modulos modELearng = new Modulos() { Nombre = "Mecánica Básica	", Area = "Tutoriales", Creditos = 2 };
            Modulos modLogProg = new Modulos() { Nombre = "Relaciones Humanas	", Area = "Tutoriales", Creditos = 3 };
            Modulos modProdDig = new Modulos() { Nombre = "Primeros Auxilios	", Area = "Tutoriales", Creditos = 2 };
            Modulos modProgWeb = new Modulos() { Nombre = "Educación Ambiental	", Area = "Tutoriales", Creditos = 3 };
            List<Modulos> lstModulos = new List<Modulos>()
            {
                modAdminDB, modDisenio, modELearng, modLogProg, modProdDig, modProgWeb, modVideoMk
            };

            // --------------------------------------------------
            resultado.Add("lstModulo", lstModulos);
            // --------------------------------------------------

            // 5.- Poner Materia en la mal
           

            // --------------------------------------------------
 
            // --------------------------------------------------

            // 6.- Prerequisitos
           

            // --------------------------------------------------
           
            // --------------------------------------------------

            // Aperturar cursos
            Curso N2D_2020PAO2_Disenio = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2020_PAO2,
                Modulos = modDisenio,
                FechaInicio = new DateTime(2020, 5, 1),
                FechaFin = new DateTime(2020, 6, 30),
                Jornada = "Diurna",
                Nombre = "Nivel 2 Diurna de Diseño Web"
            };
            Curso N2D_2020PAO2_AdminDB = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2020_PAO2,
                Modulos = modAdminDB,
                Jornada = "Diurno",
                Nombre = "Nivel 2 Diurno de Administración BBDD",
                FechaInicio = new DateTime(2020, 5, 1),
                FechaFin = new DateTime(2020, 6, 15)
            };
            Curso N3D_2021PAO1_LogProg = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2021_PAO1,
                Modulos = modLogProg,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Lógica de Programación",
                FechaInicio = new DateTime(2020, 11, 1),
                FechaFin = new DateTime(2021, 1, 30)
            };
            Curso N3D_2021PAO1_ProdDig = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2021_PAO1,
                Modulos = modProdDig,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Productos Digitales",
                FechaInicio = new DateTime(2020, 2, 10),
                FechaFin = new DateTime(2021, 3, 28)
            };
            Curso N3D_2021PAO1_VideoMk = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2021_PAO1,
                Modulos = modVideoMk,
                Jornada = "Diurno",
                Nombre = "Nivel 3 Diurno de Video Marketing",
                FechaInicio = new DateTime(2020, 4, 7),
                FechaFin = new DateTime(2021, 6, 8)
            };
            Curso N4D_2021PAO2_ProgWeb = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2021_PAO2,
                Modulos = modProgWeb,
                Jornada = "Diurno",
                Nombre = "Nivel 4 Diurno de Programación Web",
                FechaInicio = new DateTime(2021, 11, 1),
                FechaFin = new DateTime(2021, 12, 21)
            };
            Curso N4D_2021PAO2_Elearng = new Curso()
            {
                tipo = tiplicenciaB,
                Periodo = per2021_PAO2,
                Modulos = modELearng,
                Jornada = "Diurno",
                Nombre = "Nivel 4 Diurno de E-Learning",
                FechaInicio = new DateTime(2022, 1, 4),
                FechaFin = new DateTime(2022, 2, 27)
            };
            List<Curso> lstCursos = new List<Curso>() {
                // Nivel 2
                N2D_2020PAO2_AdminDB, N2D_2020PAO2_Disenio,  
                // Nivel 3
                N3D_2021PAO1_LogProg, N3D_2021PAO1_ProdDig, N3D_2021PAO1_VideoMk,
                // Nivel 4
                N4D_2021PAO2_Elearng, N4D_2021PAO2_ProgWeb
            };

            // --------------------------------------------------
            resultado.Add("lstCursos", lstCursos);
            // --------------------------------------------------

            configuracion.PeriodoVigente = per2021_PAO2;
            resultado.Add("Configuracion", configuracion);

            return resultado;
        }
    }
}



