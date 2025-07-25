using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_archivoBLL
    {
        Task<List<Tipo_archivo>> ObtenerCatalogoActivo();
    }
}
