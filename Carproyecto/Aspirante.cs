using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class Aspirante
    {
        // Atributos
        public int AspiranteID { get; set; }
        public int cedulaAsp { get; set; }
        public string NombreASP { get; set; }
        public string ApellidoAsp { get; set; }
        public string correoAsp { get; set; }
        // Relación con matrículas
        public List<Matricula> Matriculas { get; set; }



    }
}
