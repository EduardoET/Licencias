using System;
using System.Collections.Generic;
using System.Text;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Carproyecto.Operaciones
{
    public class MatriculaOP
    {
        
            public  Realacion _context;

            public MatriculaOP(Realacion context)
            {
                _context = context;
            }

            // Validación de la matrícula
            static public bool ValidarMatricula(int matriculaId)
            {
                using (var context = new Realacion(CarBDD.DBConn()))
                {
                    Matricula matricula = context.matriculas
                        .Include(matr => matr.Aspirante)
                        .Include(matr => matr.DetallesMatris)
                            .ThenInclude(det => det.Curso)
                                .ThenInclude(cur => cur.Modulos)
                                    
                                      
                                         
                        .Single(matr => matr.MatriculaId == matriculaId);
                    int Aspirante = matricula.AspiranteID;
                    // Verifica de cada materia los pre-requisitos
                    bool aprobado = true;
                    foreach (var matrDet in matricula.DetallesMatris)
                    {
                        Modulos materia = matrDet.Curso.Modulos;
                        // 1.- Materia no tiene pre-requisitos
                       
                        // 2.- Materia si tiene pre-requisitos
                        
                            // Reviso los pre-requisitos
                          
                    }
                    return aprobado;
                }
            }

            //Verifica que haya aprobado una modulo
            static public bool MateriaAprobada(int AspiranteID, int materiaId)
            {
                bool resultado = false;
                using (var context = new Realacion(CarBDD.DBConn()))
                {
                    Modulos modulos = context.modulos
                        .Include(mat => mat.Cursos)
                            .ThenInclude(cur => cur.DetallesMatris)
                                .ThenInclude(det => det.notas)
                        .Include(mat => mat.Cursos)
                            .ThenInclude(cur => cur.DetallesMatris.Where(det => det.Matricula.AspiranteID == AspiranteID))
                                .ThenInclude(det => det.Matricula)
                        .Single(mat => mat.ModulosId == materiaId);
                    foreach (var curso in modulos.Cursos)
                    {
                        foreach (var det in curso.DetallesMatris)
                        {
                            if (det.notas is null)
                            {
                                // 1.- No hay calificaciones
                                return false;
                            }
                            else
                            {
                                // 2.- Revisa calificaciónes
                               NotasOP opCalif = new NotasOP(context);
                                if (opCalif.Aprobado(det.notas))
                                    return true;
                            }
                        }
                    }
                }
                return resultado;
            }
        }
    }


    