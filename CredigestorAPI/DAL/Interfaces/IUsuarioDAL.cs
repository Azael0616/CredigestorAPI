using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IUsuarioDAL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario);
        Task<ResultadoBD> ValidarDuplicado(Usuario usuario);
    }
}
