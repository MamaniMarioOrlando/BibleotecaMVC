namespace BibleotecaMVC.Models
{
    public class Usuario
    {
        //creamos las propiedades del modelo usuario
        #region
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public string [] RolUser { get; set; }
        #endregion
    }
}
