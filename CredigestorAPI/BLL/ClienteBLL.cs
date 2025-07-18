using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.BLL.Utils;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class ClienteBLL : IClienteBLL
    {
        private readonly IClienteDAL _clienteDAL;        
        private readonly IGeneralUtils _generalUtils;
        public ClienteBLL(IClienteDAL clienteDAL, IGeneralUtils generalUtils)
        {
            _clienteDAL = clienteDAL;            
            _generalUtils = generalUtils;
        }
        public async Task<List<ClienteDTO>> ObtenerClientes()
        {
            List<ClienteDTO> _lista = await _clienteDAL.ObtenerClientes();
            return _lista;
        }
        public async Task<Cliente> ObtenerClientePorID(int clienteID)
        {
            Cliente _clienteEncontrado = await _clienteDAL.ObtenerClientePorID(clienteID);
            if (_clienteEncontrado.ClienteID == 0)
            {
                throw new HttpResponseException(404, "Cliente no encontrado");
            }
            return _clienteEncontrado;
        }
        public async Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida la CURP
            if(_cliente.CURP.Length != 18)
            {
                throw new HttpResponseException(400, "La CURP no tiene la sintaxis correcta");
            }
            //Validar si el CURP ya existe
            ResultadoBD _validacion = await _clienteDAL.ValidarDuplicado(_cliente);
            if (_validacion.Error)
            {
                throw new HttpResponseException(409, "La CURP ingresada ya existe");
            }
            if (_cliente.RFC.Length != 13)
            {
                throw new HttpResponseException(400, "El RFC no tiene la sintaxis correcta");
            }
            if (_cliente.Clave_elector.Length != 18)
            {
                throw new HttpResponseException(400, "La Clave de elector no tiene la sintaxis correcta");
            }
            //Validar el nombre
            if (string.IsNullOrWhiteSpace(_cliente.Nombre) || _cliente.Nombre?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El nombre no tiene la sintaxis correcta");
            }
            //Validar el segundo nombre
            if (_cliente.Segundo_nombre?.Length > 64)
            {
                throw new HttpResponseException(400, "El segundo nombre no tiene la sintaxis correcta");
            }
            //Validar el apellido paterno
            if (string.IsNullOrWhiteSpace(_cliente.Apellido_paterno) || _cliente.Apellido_paterno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido paterno no tiene la sintaxis correcta");
            }
            //Validar el apellido materno
            if (string.IsNullOrWhiteSpace(_cliente.Apellido_materno) || _cliente.Apellido_materno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido materno no tiene la sintaxis correcta");
            }
            //Validar la fecha de nacimiento
            if (_generalUtils.CalcularEdad(_cliente.Fecha_nacimiento) < 18)
            {
                throw new HttpResponseException(400, "La fecha de nacimiento no tiene la sintaxis correcta");
            }            
            //Validar el teléfono
            if (!string.IsNullOrWhiteSpace(_cliente.Telefono) && _cliente.Telefono?.Trim().Length != 10)
            {
                throw new HttpResponseException(400, "El teléfono no tiene la sintaxis correcta");
            }
            //Validar el prefijo del telefono
            if (!string.IsNullOrWhiteSpace(_cliente.Telefono_prefijo) && _cliente.Telefono_prefijo?.Trim().Length > 3)
            {
                throw new HttpResponseException(400, "El prefijo del teléfono no tiene la sintaxis correcta");
            }
            //Validar el correo
            if (!_generalUtils.ValidarCorreo(_cliente.Correo_electronico) || _cliente.Correo_electronico?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El correo electrónico no tiene la sintaxis correcta");
            }            
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarCliente(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarCliente(Cliente _cliente, int usuarioModificacion)
        {
            #region Validaciones
            //Valida la ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            //Valida la CURP
            if (_cliente.CURP.Length != 18)
            {
                throw new HttpResponseException(400, "La CURP no tiene la sintaxis correcta");
            }
            //Validar si el CURP ya existe
            ResultadoBD _validacion = await _clienteDAL.ValidarDuplicado(_cliente);
            if (_validacion.Error)
            {
                throw new HttpResponseException(409, "La CURP ingresada ya existe");
            }
            if (_cliente.RFC.Length != 13)
            {
                throw new HttpResponseException(400, "El RFC no tiene la sintaxis correcta");
            }
            if (_cliente.Clave_elector.Length != 18)
            {
                throw new HttpResponseException(400, "La Clave de elector no tiene la sintaxis correcta");
            }
            //Validar el nombre
            if (string.IsNullOrWhiteSpace(_cliente.Nombre) || _cliente.Nombre?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El nombre no tiene la sintaxis correcta");
            }
            //Validar el segundo nombre
            if (_cliente.Segundo_nombre?.Length > 64)
            {
                throw new HttpResponseException(400, "El segundo nombre no tiene la sintaxis correcta");
            }
            //Validar el apellido paterno
            if (string.IsNullOrWhiteSpace(_cliente.Apellido_paterno) || _cliente.Apellido_paterno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido paterno no tiene la sintaxis correcta");
            }
            //Validar el apellido materno
            if (string.IsNullOrWhiteSpace(_cliente.Apellido_materno) || _cliente.Apellido_materno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido materno no tiene la sintaxis correcta");
            }
            //Validar la fecha de nacimiento
            if (_generalUtils.CalcularEdad(_cliente.Fecha_nacimiento) < 18)
            {
                throw new HttpResponseException(400, "La fecha de nacimiento no tiene la sintaxis correcta");
            }
            //Validar el teléfono
            if (!string.IsNullOrWhiteSpace(_cliente.Telefono) && _cliente.Telefono?.Trim().Length != 10)
            {
                throw new HttpResponseException(400, "El teléfono no tiene la sintaxis correcta");
            }
            //Validar el prefijo del telefono
            if (!string.IsNullOrWhiteSpace(_cliente.Telefono_prefijo) && _cliente.Telefono_prefijo?.Trim().Length > 3)
            {
                throw new HttpResponseException(400, "El prefijo del teléfono no tiene la sintaxis correcta");
            }
            //Validar el correo
            if (!_generalUtils.ValidarCorreo(_cliente.Correo_electronico) || _cliente.Correo_electronico?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El correo electrónico no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarCliente(_cliente, usuarioModificacion);
            return _resultado;
        }
    }
}
