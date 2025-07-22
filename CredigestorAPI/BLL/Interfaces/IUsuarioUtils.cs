using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioUtils
    {
        string HashPassword(string password);
        bool ValidarPasswordLogin(string password, string hashedPassword);
        bool ValidarPasswordSegura(string password);        
        bool ValidarFechaIngreso(DateTime fechaIngreso);        
        string GenerarToken(string usuario, IConfiguration _config, int usuarioID);
    }
}
