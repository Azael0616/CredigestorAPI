using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IEstadoDAL
    {
        Task<List<Estado>> ObtenerCatalogoActivo(int paisID);
    }
}
