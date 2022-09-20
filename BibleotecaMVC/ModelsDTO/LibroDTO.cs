using BibleotecaMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace BibleotecaMVC.ModelsDTO
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        public LibroDTO() { }
        public LibroDTO(Libro libro) {
            IdLibro = libro.IdLibro;
            Titulo = libro.Titulo;
            Autor = libro.Autor;
            Genero = libro.Genero;
            FechaPublicacion=libro.FechaPublicacion;
            FechaIngreso = libro.FechaIngreso;
        }
    }
}
