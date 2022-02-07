using Microsoft.EntityFrameworkCore;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Carproyecto
{
    public class Program
    {
        static void Main(string[] args)
        {
            IngresoDatos.CrearBDEscenario1();
            IngresoDatos.InsertaMatriculasPedroJoseMaria();

            Info.ReporteNota.ReportevalMatricula(3);

        }

        static public void CreaEscenario1ValidaMatrículas()
        {
            IngresoDatos.CrearBDEscenario1();
            IngresoDatos.InsertaMatriculasPedroJoseMaria();

            ReporteNota.ReportevalMatricula(1);
            ReporteNota.ReportevalMatricula(3);
            ReporteNota.ReportevalMatricula(6);
            ReporteNota.ReportevalMatricula(9);

            using (var context = new Realacion(CarBDD.DBConn()))
            {
                int[] lstMatriculaId = new int[] { 1, 3, 6, 9 };
                foreach (var matriculaId in lstMatriculaId)
                {
                    Console.WriteLine("Matrícula Id: {0} ha sido: {1}",
                        matriculaId, MatriculaOP.ValidarMatricula(matriculaId) ? "Aprobada" : "Reprobada");
                }

            }
        }
    }




    [Serializable]
    public class ValidaMatriculaHayMateriaSinCalifException : Exception
    {
        public string modulo { get; set; }
        public int moduloid { get; set; }
        public ValidaMatriculaHayMateriaSinCalifException() { }
        public ValidaMatriculaHayMateriaSinCalifException(string mensaje) : base(mensaje) { }
        public ValidaMatriculaHayMateriaSinCalifException(string mensaje, Exception inner) : base(mensaje, inner) { }
        public ValidaMatriculaHayMateriaSinCalifException(string mensaje, string materia, int materiaId) : this(mensaje)
        {
            this.modulo = materia;
            this.moduloid = materiaId;
        }
    }

}

