using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Jornada { get; set; }
        // Relación con la carrera
        public int TipoId { get; set; }
        public tipo tipo { get; set; }
        // Relación con el Período
        public Periodo Periodo { get; set; }
        public int PeriodoId { get; set; }
        // Relación con Materia
        public int ModulosId { get; set; }
        public Modulos Modulos { get; set; }
        // Relación con Matrícula
        public List<DetallesMatri> DetallesMatris { get; set; }

    }
}
