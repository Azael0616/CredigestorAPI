using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_documentoBLL
    {
        Task<List<Tipo_documento>> ObtenerCatalogoActivo(int fomularioID);
    }
}
