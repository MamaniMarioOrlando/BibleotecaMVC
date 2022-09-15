using BibleotecaMVC.Models;

namespace BibleotecaMVC.Logica
{
    public class Log_Usuario
    {
        //region de metodos de la clase Log_usuario
        #region
        //definimos un metodo que retorna una lista de usuarios
        public List<Usuario> ListaUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario(){ Nombre="Marcelo", Email="marcelo@gmail.com", Contrasenia="marcelo123",RolUser=new string[]{ "Admin"} },
                new Usuario(){ Nombre="Mario", Email="mario@gmail.com", Contrasenia="mario123",RolUser=new string[]{ "SuperAdmin"} },
                new Usuario(){ Nombre="Marta", Email="marta@gmail.com", Contrasenia="marta123",RolUser=new string[]{ "Admin"} },
                new Usuario(){ Nombre="Florencia", Email="flor@gmail.com", Contrasenia="flor123",RolUser=new string[]{ "User"} }
            };
        }
        //Metodo que retorna el primer usuario que coincida
        //con el email y la contraseña pasadas por parameto
        public Usuario ValidarUsuario(string email,string contrasenia) 
        {
            return ListaUsuarios().Where(item =>item.Email==email && item.Contrasenia==contrasenia).FirstOrDefault();
        }
        #endregion
    }
}
