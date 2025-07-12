using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IUsuarioDAL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario, int usuarioInsercion);
        Task<ResultadoBD> ModificarUsuario(Usuario usuario, int usuarioModificacion);
        Task<ResultadoBD> ValidarDuplicado(Usuario usuario);
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<Usuario> ObtenerUsuarioPorID(int usuarioID);
        Task<UsuarioEncontrado> ObtenerUsuarioPorNombreUsuario(UsuarioLogin _usuario);
        Task<UsuarioSesion> ObtenerUsuarioSesion(int usuarioID);
    }
}
