using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioUtils
    {
        string HashPassword(string password);
        bool ValidarPasswordLogin(string password, string hashedPassword);
        bool ValidarPasswordSegura(string password);
        int CalcularEdad(DateTime fechaNacimiento);
        bool ValidarFechaIngreso(DateTime fechaIngreso);
        bool ValidarCorreo(string correo);
        string GenerarToken(string usuario, IConfiguration _config);
    }
}
