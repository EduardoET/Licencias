using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class DetallesMatri
    {
         public int DetalleMatID { get; set; }
        // Relaciones con Matricula y Curso
        public int MatriculaId { get; set; }
        public Matricula Matricula { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set;}
        // Relación Uno a Uno
        public notas notas { get; set; }
    }
}
