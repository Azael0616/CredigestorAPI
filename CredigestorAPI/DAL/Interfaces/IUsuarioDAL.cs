using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IUsuarioDAL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario);
        Task<ResultadoBD> ValidarDuplicado(Usuario usuario);
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<UsuarioLogin> ObtenerUsuarioPorNombreUsuario(UsuarioLogin _usuario);
        Task<UsuarioSesion> ObtenerUsuarioSesion(UsuarioLogin _usuario);
    }
}
