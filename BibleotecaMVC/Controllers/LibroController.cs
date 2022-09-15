using BibleotecaMVC.Context;
using BibleotecaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibleotecaMVC.Controllers
{
    public class LibroController : Controller
    {
        private readonly LibroContext _context;

        public LibroController(LibroContext context)
        {
            _context = context;
        }

        //Este metodo index retorna a la vista la lista de libros
        [Authorize(Roles ="SuperAdmin,Admin,User")]
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libros;
                
            return View(listaLibros);
        }

        [Authorize(Roles ="SuperAdmin,Admin")]
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Libro libro) 
        {
            if (ModelState.IsValid) 
            {
                libro.FechaIngreso = DateTime.Now;
                var libros=_context.Libros;
                libros.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // eneste metodo esta la logica para verificar el id y retorna a la vista de editar lo slibros
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Editar(int? id) 
        {
            if (id == 0 || id == null)
            {
                return NotFound("El Id no es valido ");
            }
            else 
            {
                var libros = _context.Libros.Find(id);
                if (libros==null)
                {
                    return NotFound("El Libro no existe");
                }
                return View(libros);
            }
        }

        [HttpPost]
        public IActionResult Editar(Libro libro) 
        {
            if (ModelState.IsValid)
            {
                libro.FechaIngreso = DateTime.Now;
                var libros = _context.Libros;
                libros.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Eliminar(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("El Id no es valido ");
            }
            else
            {
                var libros = _context.Libros.Find(id);
                if (libros == null)
                {
                    return NotFound("El Libro no existe");
                }
                return View(libros);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Libro libro) 
        {
            if (ModelState.IsValid) 
            {
                var libros = _context.Libros;
                libros.Remove(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
