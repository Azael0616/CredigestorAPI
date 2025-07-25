using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IPaisBLL
    {
        Task<List<Pais>> ObtenerCatalogoActivo();
    }
}
