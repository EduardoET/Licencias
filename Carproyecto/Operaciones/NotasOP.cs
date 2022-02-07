
using Microsoft.EntityFrameworkCore;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Carproyecto.Operaciones
{
    public class NotasOP
    {
        public Realacion _context;

        float pesoNota1, pesoNota2, pesoNota3, pesoNota4, notaMinima;

        public NotasOP (Realacion context)
        {
            _context = context;
            // Carga los parámetros para calcular la nota final
            var config = context.configs
                .Include(ctx => ctx.PeriodoVigente)
                .Single(ctx => ctx.ConfigId == 1);
            pesoNota1 = config.PesoNota1;
            pesoNota2 = config.PesoNota2;
            pesoNota3 = config.PesoNota3;
            pesoNota4 = config.PesoNota4;
            notaMinima = config.NotaMinima;
        }

        public bool Aprobado(int notaID)
        {
            notas not = _context.notas
                .Single(not => not.notaId == notaID);
            return Aprobado(not);
        }

        public bool Aprobado(notas not)
        {
            return not.Aprueba(pesoNota1, pesoNota2, pesoNota3, pesoNota4,notaMinima);
        }

        public float NotaFinal(notas not)
        {
            return not.NotaFinal(pesoNota1, pesoNota2, pesoNota3, pesoNota4);
        }

        public void RegistrarNotas(DetallesMatri det, notas not)
        {
            det.notas = not;

            try
            {
                _context.notas.Add(not);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Exception ex = new Exception("Conficto de concurrencia", exception);
                throw ex;
            }
        }
    }
}
