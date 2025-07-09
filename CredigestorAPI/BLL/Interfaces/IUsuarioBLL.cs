using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario);
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<UsuarioLogin> ObtenerUsuarioPorNombreUsuario(UsuarioLogin _usuario);
        Task<UsuarioSesion> ObtenerUsuarioSesion(UsuarioLogin _usuario, IConfiguration _config);
    }
}
