using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioUtils
    {
        string HashPassword(Usuario _usuario, string password);
        bool ValidarPasswordLogin(Usuario _usuario, string password, string hashedPassword);
        bool ValidarPasswordSegura(string password);
        int CalcularEdad(DateTime fechaNacimiento);
        bool ValidarFechaIngreso(DateTime fechaIngreso);
        bool ValidarCorreo(string correo);
    }
}
