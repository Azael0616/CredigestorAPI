using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_documentoDAL
    {
        Task<List<Tipo_documento>> ObtenerCatalogoActivo(int fomularioID);
    }
}
