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
            return await _clienteDAL.ObtenerClientes();            
        }        
        public async Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida la CURP
            if(_cliente.CURP.Length != 18)
            {
                throw new HttpResponseException(400, "La CURP no tiene la sintaxis correcta");
            }            
            if (_cliente.RFC.Length <12 || _cliente.RFC.Length>13)
            {
                throw new HttpResponseException(400, "El RFC no tiene la sintaxis correcta");
            }
            if (_cliente.Clave_elector.Length != 18)
            {
                throw new HttpResponseException(400, "La Clave de elector no tiene la sintaxis correcta");
            }
            //Validar si el CURP|RFC|Clave_elector ya existe
            ResultadoBD _validacion = await _clienteDAL.ValidarDuplicado(_cliente);
            if (_validacion.Error)
            {
                throw new HttpResponseException(409, _validacion.ErrorDesc);
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
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
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
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarCliente(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<ResultadoBD> InsertarClienteDireccion(Cliente_direccion _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida el ClienteID
            if(_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            //Valida la calle
            if (_cliente.Calle.Length <= 0 || _cliente.Calle.Length > 128)
            {
                throw new HttpResponseException(400, "La Calle no tiene la sintaxis correcta");
            }
            //Valida el numero exterior
            if (_cliente.Numero_exterior.Length <= 0 || _cliente.Numero_exterior.Length > 10)
            {
                throw new HttpResponseException(400, "El Número exterior no tiene la sintaxis correcta");
            }
            //Valida el numero interior
            if (_cliente.Numero_interior.Length > 10)
            {
                throw new HttpResponseException(400, "El Número interior no tiene la sintaxis correcta");
            }
            //Valida la entre calle 1
            if (_cliente.Entre_calle1.Length > 128)
            {
                throw new HttpResponseException(400, "La Entre calle 1 no tiene la sintaxis correcta");
            }
            //Valida la entre calle 2
            if (_cliente.Entre_calle2.Length > 128)
            {
                throw new HttpResponseException(400, "La Entre calle 2 no tiene la sintaxis correcta");
            }
            //Valida la colonia
            if (_cliente.Colonia.Length <= 0 || _cliente.Colonia.Length > 128)
            {
                throw new HttpResponseException(400, "La Colonia no tiene la sintaxis correcta");
            }
            //Valida el PaisID
            if (_cliente.PaisID <= 0)
            {
                throw new HttpResponseException(400, "El PaisID no tiene la sintaxis correcta");
            }
            //Valida el EstadoID
            if (_cliente.EstadoID <= 0)
            {
                throw new HttpResponseException(400, "El EstadoID no tiene la sintaxis correcta");
            }
            //Valida el MunicipioID
            if (_cliente.MunicipioID <= 0)
            {
                throw new HttpResponseException(400, "El MunicipioID no tiene la sintaxis correcta");
            }
            //Valida la Referencia casa
            if (_cliente.Referencia_casa.Length > 255)
            {
                throw new HttpResponseException(400, "La Referencia casa no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClienteDireccion(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarClienteDireccion(Cliente_direccion _cliente, int usuarioModificacion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            //Valida la calle
            if (_cliente.Calle.Length <= 0 || _cliente.Calle.Length > 128)
            {
                throw new HttpResponseException(400, "La Calle no tiene la sintaxis correcta");
            }
            //Valida el numero exterior
            if (_cliente.Numero_exterior.Length <= 0 || _cliente.Numero_exterior.Length > 10)
            {
                throw new HttpResponseException(400, "El Número exterior no tiene la sintaxis correcta");
            }
            //Valida el numero interior
            if (_cliente.Numero_interior.Length > 10)
            {
                throw new HttpResponseException(400, "El Número interior no tiene la sintaxis correcta");
            }
            //Valida la entre calle 1
            if (_cliente.Entre_calle1.Length > 128)
            {
                throw new HttpResponseException(400, "La Entre calle 1 no tiene la sintaxis correcta");
            }
            //Valida la entre calle 2
            if (_cliente.Entre_calle2.Length > 128)
            {
                throw new HttpResponseException(400, "La Entre calle 2 no tiene la sintaxis correcta");
            }
            //Valida la colonia
            if (_cliente.Colonia.Length <= 0 || _cliente.Colonia.Length > 128)
            {
                throw new HttpResponseException(400, "La Colonia no tiene la sintaxis correcta");
            }
            //Valida el PaisID
            if (_cliente.PaisID <= 0)
            {
                throw new HttpResponseException(400, "El PaisID no tiene la sintaxis correcta");
            }
            //Valida el EstadoID
            if (_cliente.EstadoID <= 0)
            {
                throw new HttpResponseException(400, "El EstadoID no tiene la sintaxis correcta");
            }
            //Valida el MunicipioID
            if (_cliente.MunicipioID <= 0)
            {
                throw new HttpResponseException(400, "El MunicipioID no tiene la sintaxis correcta");
            }
            //Valida la Referencia casa
            if (_cliente.Referencia_casa.Length > 255)
            {
                throw new HttpResponseException(400, "La Referencia Casa no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarClienteDireccion(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<ResultadoBD> InsertarClienteDocumento(Cliente_documento _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.TipoDocumentoID <= 0)
            {
                throw new HttpResponseException(400, "El TipoDocumentoID no tiene la sintaxis correcta");
            }
            if (_cliente.Contenido.Length == 0)
            {
                throw new HttpResponseException(400, "El Contenido no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClienteDocumento(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarClienteDocumento(Cliente_documento _cliente, int usuarioModificacion)
        {
            #region Validaciones
            if (_cliente.DocumentoID <= 0)
            {
                throw new HttpResponseException(400, "El DocumentoID no tiene la sintaxis correcta");
            }
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.TipoDocumentoID <= 0)
            {
                throw new HttpResponseException(400, "El TipoDocumentoID no tiene la sintaxis correcta");
            }
            if (_cliente.Contenido.Length == 0)
            {
                throw new HttpResponseException(400, "El Contenido no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClienteDocumento(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<ResultadoBD> InsertarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_anteriores < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos anteriores no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_liquidados < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos liquidados no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_liquidados < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos liquidados no tiene la sintaxis correcta");
            }
            if(_cliente.Tiene_comprobantes == true)
            {
                if(_cliente.Comprobante_digitalizado.Length == 0)
                {
                    throw new HttpResponseException(400, "El Comprobante digitalizado no tiene la sintaxis correcta");
                }
                if(_cliente.TipoDocumentoID <=0)
                {
                    throw new HttpResponseException(400, "El TipoDocumentoID no tiene la sintaxis correcta");
                }
            }
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClienteHistorialPrevio(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioModificacion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_anteriores < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos anteriores no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_liquidados < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos liquidados no tiene la sintaxis correcta");
            }
            if (_cliente.Total_creditos_liquidados < 0)
            {
                throw new HttpResponseException(400, "El Total de creditos liquidados no tiene la sintaxis correcta");
            }
            if (_cliente.Tiene_comprobantes == true)
            {
                if (_cliente.Comprobante_digitalizado.Length == 0)
                {
                    throw new HttpResponseException(400, "El Comprobante digitalizado no tiene la sintaxis correcta");
                }
                if (_cliente.TipoDocumentoID <= 0)
                {
                    throw new HttpResponseException(400, "El TipoDocumentoID no tiene la sintaxis correcta");
                }
            }
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarClienteHistorialPrevio(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<ResultadoBD> InsertarClientePerfil(Cliente_perfil _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.Nivel_estudio < 0)
            {
                throw new HttpResponseException(400, "El Nivel de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Area_estudio < 0)
            {
                throw new HttpResponseException(400, "El Área de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Area_ocupacion < 0)
            {
                throw new HttpResponseException(400, "El Área de ocupación no tiene la sintaxis correcta");
            }
            if (_cliente.Carrera_estudio.Length > 128)
            {
                throw new HttpResponseException(400, "La Carrera de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Puesto.Length <= 0 || _cliente.Puesto.Length > 128)
            {
                throw new HttpResponseException(400, "El Puesto no tiene la sintaxis correcta");
            }
            if (_cliente.Empresa.Length <= 0 || _cliente.Empresa.Length > 128)
            {
                throw new HttpResponseException(400, "La Empresa no tiene la sintaxis correcta");
            }
            if (_cliente.Ingreso_mensual < 0)
            {
                throw new HttpResponseException(400, "El Ingreso mensual no tiene la sintaxis correcta");
            }
            if (_cliente.Gasto_mensual < 0)
            {
                throw new HttpResponseException(400, "El Gasto mensual no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClientePerfil(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarClientePerfil(Cliente_perfil _cliente, int usuarioModificacion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.Nivel_estudio < 0)
            {
                throw new HttpResponseException(400, "El Nivel de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Area_estudio < 0)
            {
                throw new HttpResponseException(400, "El Área de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Area_ocupacion < 0)
            {
                throw new HttpResponseException(400, "El Área de ocupación no tiene la sintaxis correcta");
            }
            if (_cliente.Carrera_estudio.Length > 128)
            {
                throw new HttpResponseException(400, "La Carrera de estudio no tiene la sintaxis correcta");
            }
            if (_cliente.Puesto.Length <= 0 || _cliente.Puesto.Length > 128)
            {
                throw new HttpResponseException(400, "El Puesto no tiene la sintaxis correcta");
            }
            if (_cliente.Empresa.Length <= 0 || _cliente.Empresa.Length > 128)
            {
                throw new HttpResponseException(400, "La Empresa no tiene la sintaxis correcta");
            }
            if (_cliente.Ingreso_mensual < 0)
            {
                throw new HttpResponseException(400, "El Ingreso mensual no tiene la sintaxis correcta");
            }
            if (_cliente.Gasto_mensual < 0)
            {
                throw new HttpResponseException(400, "El Gasto mensual no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarClientePerfil(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<ResultadoBD> InsertarClienteReferencia(Cliente_referencia _cliente, int usuarioInsercion)
        {
            #region Validaciones
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }            
            if (_cliente.Nombre_completo.Length <= 0 || _cliente.Nombre_completo.Length > 255)
            {
                throw new HttpResponseException(400, "El Nombre completo no tiene la sintaxis correcta");
            }
            if (_cliente.Telefono_referencia.Length != 10)
            {
                throw new HttpResponseException(400, "El Telefono no tiene la sintaxis correcta");
            }
            if (_cliente.Telefono_referencia_prefijo.Length <= 0 || _cliente.Telefono_referencia_prefijo.Length > 3)
            {
                throw new HttpResponseException(400, "El Prefijo del telefono no tiene la sintaxis correcta");
            }
            if (_cliente.Correo_electronico.Length > 64)
            {
                throw new HttpResponseException(400, "El Correo electrónico no tiene la sintaxis correcta");
            }            
            //Valida el UsuarioID_insercion
            if (usuarioInsercion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.InsertarClienteReferencia(_cliente, usuarioInsercion);
            return _resultado;
        }
        public async Task<ResultadoBD> ModificarClienteReferencia(Cliente_referencia _cliente, int usuarioModificacion)
        {
            #region Validaciones
            if (_cliente.ReferenciaID <= 0)
            {
                throw new HttpResponseException(400, "La ReferenciaID no tiene la sintaxis correcta");
            }
            //Valida el ClienteID
            if (_cliente.ClienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            if (_cliente.Nombre_completo.Length <= 0 || _cliente.Nombre_completo.Length > 255)
            {
                throw new HttpResponseException(400, "El Nombre completo no tiene la sintaxis correcta");
            }
            if (_cliente.Telefono_referencia.Length != 10)
            {
                throw new HttpResponseException(400, "El Teléfono no tiene la sintaxis correcta");
            }
            if (_cliente.Telefono_referencia_prefijo.Length <= 0 || _cliente.Telefono_referencia_prefijo.Length > 3)
            {
                throw new HttpResponseException(400, "El Prefijo del teléfono no tiene la sintaxis correcta");
            }
            if (_cliente.Correo_electronico.Length > 64)
            {
                throw new HttpResponseException(400, "El Correo electrónico no tiene la sintaxis correcta");
            }
            //Valida el UsuarioID_insercion
            if (usuarioModificacion <= 0)
            {
                throw new HttpResponseException(400, "El UsuarioID no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _clienteDAL.ModificarClienteReferencia(_cliente, usuarioModificacion);
            return _resultado;
        }
        public async Task<Cliente> ObtenerClientePorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            Cliente _clienteEncontrado = await _clienteDAL.ObtenerClientePorID(clienteID);
            return _clienteEncontrado;
        }
        public async Task<Cliente_direccion> ObtenerClienteDireccionPorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            Cliente_direccion _clienteEncontrado = await _clienteDAL.ObtenerClienteDireccionPorID(clienteID);            
            return _clienteEncontrado;
        }
        public async Task<List<Cliente_documento>> ObtenerClienteDocumentoPorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            List<Cliente_documento> _clienteEncontrado = await _clienteDAL.ObtenerClienteDocumentoPorID(clienteID);
            return _clienteEncontrado;
        }
        public async Task<Cliente_historial_previo> ObtenerClienteHistorialPrevioPorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            Cliente_historial_previo _clienteEncontrado = await _clienteDAL.ObtenerClienteHistorialPrevioPorID(clienteID);
            return _clienteEncontrado;
        }
        public async Task<Cliente_perfil> ObtenerClientePerfilPorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            Cliente_perfil _clienteEncontrado = await _clienteDAL.ObtenerClientePerfilPorID(clienteID);
            return _clienteEncontrado;
        }
        public async Task<List<Cliente_referencia>> ObtenerClienteReferenciaPorID(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new HttpResponseException(400, "El ClienteID no tiene la sintaxis correcta");
            }
            List<Cliente_referencia> _clienteEncontrado = await _clienteDAL.ObtenerClienteReferenciaPorID(clienteID);
            return _clienteEncontrado;
        }
    }
}
