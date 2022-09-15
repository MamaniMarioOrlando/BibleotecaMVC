using BibleotecaMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BibleotecaMVC.Context
{
    public class LibroContext:DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public LibroContext(DbContextOptions<LibroContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creamos la tabla Libro
            modelBuilder.Entity<Libro>(libro => 
            {
                //Definimos el nombre de la tabla
                libro.ToTable("Libro");
                //asignanos la Primary Key
                libro.HasKey(l => l.IdLibro);
                //asignamos las siguientes propiedades
                libro.Property(l => l.Titulo).HasMaxLength(45);
                libro.Property(l => l.Autor).HasMaxLength(30);
                libro.Property(l => l.Genero).HasMaxLength(150);
                libro.Property(l => l.FechaPublicacion);
                libro.Property(l => l.FechaIngreso);
            });
        }

    }
}
