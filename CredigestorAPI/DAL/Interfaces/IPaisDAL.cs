using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IPaisDAL
    {
        Task<List<Pais>> ObtenerCatalogoActivo();
    }
}
