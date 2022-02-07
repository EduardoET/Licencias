
using Carproyecto.HerramientasBDD;
using Carproyecto.Operaciones;
using Carproyecto.Info;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carproyecto.Relaciones
{
    public class Realacion : DbContext
    {
    
    
        public DbSet<Aspirante> aspirantes { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Modulos> modulos { get; set; }
        public DbSet<Matricula> matriculas { get; set; }
        public DbSet<DetallesMatri> detallesMatris { get; set; }
        public DbSet<Config> configs { get; set; }
        public DbSet<notas> notas { get; set; }
        public DbSet<tipo> tipos { get; set; }
      
        public DbSet<Periodo> periodos { get; set; }
     
       

        // Constructor vacio
        public Realacion() : base()
        {

        }

        // Constructor para pasar la conexión al padre
        public Realacion(DbContextOptions<Realacion> opciones)
            : base(opciones)
        {

        }

        // Modelado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion
            modelBuilder.Entity<Config>()
                .HasOne(config => config.PeriodoVigente)
                .WithMany()
                .HasForeignKey(config => config.PeriodoVigenteId);

            // Relación uno a muchos; un Estudiante tiene muchas Matrículas 
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.Aspirante)
                .WithMany(est => est.Matriculas)
                .HasForeignKey(mat => mat.AspiranteID);

            // Relación uno a muchos; una Matrícula a una tipo
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.tipo)
                .WithMany(tip => tip.Matriculas)
                .HasForeignKey(mat => mat.TipoId);

            // Relación uno a muchos; en un período se registran varias matrículas
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.Periodo)
                .WithMany(per => per.Matriculas)
                .HasForeignKey(mat => mat.PeriodoId);

            // Relación de uno a muchos: cabecera detalle de la matrícula
            modelBuilder.Entity<DetallesMatri>()
                .HasOne(det => det.Matricula)
                .WithMany(mat => mat.DetallesMatris)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(det => det.MatriculaId);

            // Relación de uno a muchos: Cursos con detalles de la matrícula
            modelBuilder.Entity<DetallesMatri>()
                .HasOne(det => det.Curso)
                .WithMany(cur => cur.DetallesMatris)
                .HasForeignKey(det => det.CursoId);

            // Relación uno a uno; una Matrícula_Det tiene una Calificación
            modelBuilder.Entity<DetallesMatri>()
           .HasOne(det => det.notas)
           .WithOne(notas => notas.detallesMatri)
           .HasForeignKey<notas>(notas => notas.DetallesMatri);

            // Relación uno a muchos; una Materia se dicta en muchos Cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Modulos)
                .WithMany(mat => mat.Cursos)
                .HasForeignKey(cur => cur.ModulosId);

            // Relación uno a muchos; una Tipo tiene varios Cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.tipo)
                .WithMany(tip => tip.Cursos)
                .HasForeignKey(cur => cur.TipoId);

            // Relación uno a muchos; un Período tiene varios cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Periodo)
                .WithMany(per => per.Cursos)
                .HasForeignKey(cur => cur.PeriodoId);

            // Relación uno a uno de Malla con Materia
           

            // Relación Malla - Prerequisitos - Matrias
        

        }

        // Se mantiene para la creación de la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn;
                conn = CarBDD.connSqlServer;
                optionsBuilder.UseSqlServer(conn);
            }
        }

    }
}
    

