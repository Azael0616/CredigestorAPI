using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IEstadoBLL
    {
        Task<List<Estado>> ObtenerCatalogoActivo(int paisID);
    }
}
