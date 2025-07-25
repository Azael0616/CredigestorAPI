using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IMunicipioBLL
    {
        Task<List<Municipio>> ObtenerCatalogoActivo(int estadoID);
    }
}
