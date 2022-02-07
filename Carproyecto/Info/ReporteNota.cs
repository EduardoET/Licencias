using System;
using System.Collections.Generic;
using System.Text;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Carproyecto.Info
{
    public class ReporteNota
    {
        // Reporte de calificaciones de un estudiante
        static public void CalificacionesPorAspirante(string aspNombre)
        {
            Console.WriteLine("Reporte de Notas del Aspirante {0}", aspNombre);
            // Consulta las notas de un estudiante
            using (var context = new Realacion (CarBDD.DBConn()))
            {
                var aspirante = context.aspirantes
                    .Include(asp => asp.Matriculas)
                        .ThenInclude(matr => matr.DetallesMatris)
                            .ThenInclude(det => det.notas)
                    .Include(asp => asp.Matriculas)
                        .ThenInclude(matr => matr.DetallesMatris)
                            .ThenInclude(det => det.Curso)
                    .Include(asp => asp.Matriculas)
                        .ThenInclude(matr => matr.Periodo)
                    .Single(asp => asp.NombreASP.Equals(aspNombre));
                // Barre las matrículas del estudiante
                foreach (var matricula in aspirante.Matriculas)
                {
                    Console.WriteLine("Matricula Id: {0} Período: {0:yyyy/dd/MM} - {1:yyyy/dd/MM}",
                        matricula.MatriculaId, matricula.Periodo.FechaInicio, matricula.Periodo.FechaFin);
                    // Barre los detalles de cada matrícula
                    foreach (var matrDet in matricula.DetallesMatris)
                    {
                        Console.WriteLine(" Det: {0} - Curso {1}", matrDet.DetalleMatID, matrDet.Curso.Nombre);
                        if (matrDet.notas != null)
                        {
                            NotasOP notasOP = new NotasOP(context);
                            notas not = matrDet.notas;
                            Console.WriteLine(" Calif Id: {0}", matrDet.notas.notaId);
                            Console.WriteLine("    Nota 1   Nota 2   Nota3  Nota Final");
                            Console.WriteLine("    {0:#0.00}     {1:#0.00}     {2:#0.00}   {3:#0.00}  --> {4}",
                                not.Nota1, not.Nota2, not.Nota3, not.Nota4,
                                notasOP.NotaFinal(not),
                                notasOP.Aprobado(not) ? "Aprueba" : "Reprueba"
                            );
                        }
                    }
                }
            }
        }

        // Reporte de calificaciones de un curso
        static public void CalificacionesPorCurso(string CursoNombre)
        {
            using (var context = new Realacion(CarBDD.DBConn()))
            {
                Curso curso = context.cursos
                    .Include(cur => cur.DetallesMatris)
                        .ThenInclude(det => det.notas)
                    .Include(cur => cur.DetallesMatris)
                        .ThenInclude(det => det.Matricula)
                            .ThenInclude(matr => matr.Aspirante)
                    .Single(cur => cur.Nombre == CursoNombre);

                Console.WriteLine("Curso Id: {0} - {1}",
                    curso.CursoId, curso.Nombre);
                foreach (var det in curso.DetallesMatris)
                {
                    Console.WriteLine("  {0}", det.Matricula.Aspirante.NombreASP);
                    if (det.notas != null)
                    {
                        NotasOP notasOP = new NotasOP(context);
                        Console.WriteLine("    Nota 1   Nota 2   Nota 3  Nota 3 Nota Final");
                        Console.WriteLine("    {0:#0.00}     {1:#0.00}     {2:#0.00}     {3:#0.00}   -->{4}",
                            det.notas.Nota1, det.notas.Nota2, det.notas.Nota3, det.notas.Nota4,
                            notasOP.NotaFinal(det.notas), notasOP.Aprobado(det.notas));
                    }
                    else
                    {
                        Console.WriteLine("    Sin Calificaciones");
                    }
                }
            }

        }

        // Reporte explicativo de la validación de la matrícula
        static public bool ReportevalMatricula(int matriculaId)
        {
            using (var context = new Realacion(CarBDD.DBConn()))
            {
                Matricula matricula = context.matriculas
                    .Include(matr => matr.Aspirante)
                    .Include(matr => matr.DetallesMatris)
                        .ThenInclude(det => det.Curso)
                            .ThenInclude(cur => cur.Modulos)
                               
                                  
                    .Single(matr => matr.MatriculaId == matriculaId);
                Console.WriteLine(" ");
                Console.WriteLine("Análisis de la matrícula {0} de {1}",
                    matricula.MatriculaId, matricula.Aspirante.NombreASP);
                int AspiranteID = matricula.AspiranteID;
                // Verifica de cada materia los pre-requisitos
                bool aprobado = true;
                foreach (var matrDet in matricula.DetallesMatris)
                {
                    Console.WriteLine("    .");
                    Console.WriteLine("   [ ] Curso: {0}", matrDet.Curso.Nombre);
                    Modulos materia = matrDet.Curso.Modulos;
                    // 1.- Materia no tiene pre-requisitos
                   
                        
                        
                    
                }
                Console.WriteLine("   --------------------------------------------");
                Console.WriteLine("   RESULTADO: La matrícula es {0}", aprobado ? "APROBADA" : "RECHAZADA");
                return aprobado;
            }
        }
    }
}

