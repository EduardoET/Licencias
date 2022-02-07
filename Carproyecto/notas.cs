using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto
{
    public class notas
    {
       
        // Relación Uno a Uno
        public int DetalleMatID { get; set; }
        public DetallesMatri DetallesMatri { get; set; }
        public int notaId { get; set; }
        public float Nota1 { get; set; }
        public float Nota2 { get; set; }
        public float Nota3 { get; set; }
        public float Nota4 { get; set; }

        
        // Relación Uno a Uno
        public int Matricula_DetId { get; set; }
        public DetallesMatri detallesMatri { get; set; }


        // Cálculo de la nota final
        public float NotaFinal(float peso1, float peso2, float peso3, float peso4)
        {
            // Cálculo
            float suma = 0;
            suma += MathF.Round(Nota1 * peso1, 2);
            suma += MathF.Round(Nota2 * peso2, 2);
            suma += MathF.Round(Nota3 * peso3, 2);
            suma += MathF.Round(Nota4 * peso4, 2);
            suma = MathF.Round(suma, 2);
            return suma;
        }
        // Verifica si cumple el mínimo
        public bool Aprueba(float peso1, float peso2, float peso3, float peso4, float NotaMinima)
        {
            bool res;
            res = NotaFinal(peso1, peso2, peso3, peso4) >= NotaMinima;
            return res;
        }

    }
}
