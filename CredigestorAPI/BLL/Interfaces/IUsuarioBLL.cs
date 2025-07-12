using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario, int usuarioInsercion);
        Task<ResultadoBD> ModificarUsuario(Usuario usuario, int usuarioModificacion);
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<Usuario> ObtenerUsuarioPorID(int usuarioID);
        Task<UsuarioEncontrado> ObtenerUsuarioPorNombreUsuario(UsuarioLogin _usuario);
        Task<string> ObtenerToken(UsuarioLogin _usuario, IConfiguration _config);
        Task<UsuarioSesion> ObtenerUsuarioSesion(int usuarioID);
    }
}
