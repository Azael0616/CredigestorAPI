using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IClienteBLL
    {        
        Task<List<ClienteDTO>> ObtenerClientes();
        Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarCliente(Cliente _cliente, int usuarioModificacion);
        Task<ResultadoBD> InsertarClienteDireccion(Cliente_direccion _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarClienteDireccion(Cliente_direccion _cliente, int usuarioModificacion);
        Task<ResultadoBD> InsertarClienteDocumento(Cliente_documento _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarClienteDocumento(Cliente_documento _cliente, int usuarioModificacion);
        Task<ResultadoBD> InsertarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioModificacion);
        Task<ResultadoBD> InsertarClientePerfil(Cliente_perfil _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarClientePerfil(Cliente_perfil _cliente, int usuarioModificacion);
        Task<ResultadoBD> InsertarClienteReferencia(Cliente_referencia _cliente, int usuarioInsercion);
        Task<ResultadoBD> ModificarClienteReferencia(Cliente_referencia _cliente, int usuarioModificacion);
        Task<Cliente> ObtenerClientePorID(int clienteID);
        Task<Cliente_direccion> ObtenerClienteDireccionPorID(int clienteID);
        Task<List<Cliente_documento>> ObtenerClienteDocumentoPorID(int clienteID);
        Task<Cliente_historial_previo> ObtenerClienteHistorialPrevioPorID(int clienteID);
        Task<Cliente_perfil> ObtenerClientePerfilPorID(int clienteID);
        Task<List<Cliente_referencia>> ObtenerClienteReferenciaPorID(int clienteID);
    }
}
