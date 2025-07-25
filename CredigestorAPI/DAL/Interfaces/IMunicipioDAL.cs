using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IMunicipioDAL
    {
        Task<List<Municipio>> ObtenerCatalogoActivo(int estadoID);
    }
}
