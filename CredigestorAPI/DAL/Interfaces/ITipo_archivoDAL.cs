using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_archivoDAL
    {
        Task<List<Tipo_archivo>> ObtenerCatalogoActivo();
    }
}
