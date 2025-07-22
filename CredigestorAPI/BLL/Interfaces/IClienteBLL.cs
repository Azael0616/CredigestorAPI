using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IClienteBLL
    {
        Task<Cliente> ObtenerClientePorID(int clienteID);
        Task<List<ClienteDTO>> ObtenerClientes();
        Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarCliente(Cliente _cliente, int usuarioModificacion);
    }
}
