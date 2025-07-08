using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<ResultadoBD> InsertarUsuario(Usuario usuario);
    }
}
