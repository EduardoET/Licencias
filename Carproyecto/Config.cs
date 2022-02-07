using Microsoft.EntityFrameworkCore;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class Config
    {
        public int ConfigId { get; set; }
        public string AgenciaNombre { get; set; }
        // Período vigente
        public Periodo PeriodoVigente { get; set; }
        public int PeriodoVigenteId { get; set; }
        // Control de créditos
        public int CreditosMaximo { get; set; }
        // Pesos de cada nota
        public float PesoNota1 { get; set; }
        public float PesoNota2 { get; set; }
        public float PesoNota3 { get; set; }
        public float PesoNota4 { get; set; }
        // Nota mínima 
        public float NotaMinima { get; set; }
    }

}

