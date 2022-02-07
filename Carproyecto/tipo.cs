using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class tipo
    {
        public int TipoId { get; set; }
        public string Nivel { get; set; }
        public string NombreTipo { get; set; }
        public float CostoCredito { get; set; }
        public tipo Tipo { get; set; }
        public int ModuloId { get; set; }
        public Modulos Modulos { get; set; }

        public List<Matricula> Matriculas { get; set; }
        // Relación con los cursos
        public List<Curso> Cursos { get; set; }



    }
}
