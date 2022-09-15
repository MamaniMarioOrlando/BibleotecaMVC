using BibleotecaMVC.Logica;
using BibleotecaMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BibleotecaMVC.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _user)
        {
            //creamos un objeto de tipo Log_Usuario para obtener la lista de los usuarios
            Log_Usuario logUsuario=new Log_Usuario();
            //declaramos una variable para almacenar el Usuario retornado por el
            //metodo de validarUsuario
            var usuario = logUsuario.ValidarUsuario(_user.Email, _user.Contrasenia);

            if (usuario!=null)
            {
                //creamos los objetos cliam
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Email)
                };
                foreach (var rol in usuario.RolUser)
                {
                    claims.Add(new Claim(ClaimTypes.Role,rol));
                }
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //Metodo que me permite terminar con la sesion
        public async Task<IActionResult> Salir() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Acceso");
        }
    }
}
