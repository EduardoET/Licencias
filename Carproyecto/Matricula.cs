using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class Matricula
    {
        // Datos generales
        public int MatriculaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }   // PENdiente, APRobada, ANUlada
        // Relación con el estudiante
        public int AspiranteID { get; set; }
        public Aspirante Aspirante { get; set; }
        // Relación con la carrera
        public tipo tipo { get; set; }
        public int TipoId { get; set; }
        // Relación con el período
        public Periodo Periodo { get; set; }
        public int PeriodoId { get; set; }
        // Detalles de la matrícula
        public List<DetallesMatri> DetallesMatris { get; set; }

    }
}
