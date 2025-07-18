using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IClienteDAL
    {
        Task<Cliente> ObtenerClientePorID(int clienteID);
        Task<List<ClienteDTO>> ObtenerClientes();
        Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarCliente(Cliente _cliente, int usuarioModificacion);
        Task<ResultadoBD> ValidarDuplicado(Cliente usuario);
    }
}
