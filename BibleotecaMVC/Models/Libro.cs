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
        [Display(Name = "Fecha Publicacion")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
    }
}
