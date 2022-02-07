using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class Modulos
    {
        public int ModulosId { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public int Creditos { get; set; }
        // Relación con Cursos
        public List<Curso> Cursos { get; set; }
    }
}
