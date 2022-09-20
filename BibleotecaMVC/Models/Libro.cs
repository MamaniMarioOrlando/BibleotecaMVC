using BibleotecaMVC.ModelsDTO;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BibleotecaMVC.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Libro() { }
        public Libro(LibroDTO libroDto) 
        {
            IdLibro = libroDto.IdLibro;
            Titulo = libroDto.Titulo;
            Autor = libroDto.Autor;
            Genero = libroDto.Genero;
            FechaPublicacion = libroDto.FechaPublicacion;
            FechaIngreso = libroDto.FechaIngreso;
        }
    }
}
