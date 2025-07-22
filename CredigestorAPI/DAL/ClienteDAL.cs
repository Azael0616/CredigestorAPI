using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class ClienteDAL : IClienteDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public ClienteDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Inserta la información de un cliente
        public async Task<ResultadoBD> InsertarCliente(Cliente _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@Nombre", _cliente.Nombre.Trim().ToUpper()  },
                { "@Segundo_nombre", _cliente.Segundo_nombre.Trim().ToUpper() },
                { "@Apellido_paterno", _cliente.Apellido_paterno.Trim().ToUpper()  },
                { "@Apellido_materno", _cliente.Apellido_materno?.Trim().ToUpper()  },
                { "@Fecha_nacimiento", _cliente.Fecha_nacimiento  },
                { "@TipoSexoID", _cliente.TipoSexoID  },
                { "@TipoEstadoCivilID", _cliente.TipoEstadoCivilID },
                { "@CURP", _cliente.CURP.Trim().ToUpper() },
                { "@RFC", _cliente.RFC.Trim().ToUpper() },
                { "@Clave_elector", _cliente.Clave_elector.Trim().ToUpper() },
                { "@Telefono", _cliente.Telefono.Trim().ToLower()  },
                { "@Telefono_prefijo", _cliente.Telefono_prefijo.Trim() },
                { "@Correo_electronico", _cliente.Correo_electronico.Trim().ToLower()},
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Cliente_I_PorModelo", parameters);

            if (dt == null)
                return _resultado;
            else
            {
                _resultado.Error = Convert.ToBoolean(dt["Error"]);
                _resultado.ErrorDesc = dt["ErrorDesc"] != null ? dt["ErrorDesc"].ToString() : "";
                _resultado.Icon = dt["Icon"] != null ? dt["Icon"].ToString() : "";
                _resultado.ValorAuxiliar = dt["ValorAuxiliar"] != null ? int.Parse(dt["ValorAuxiliar"].ToString()) : 0;
                _resultado.Code = 200;
                return _resultado;
#nullable enable
            }
        }
        //Modifica la información de un cliente
        public async Task<ResultadoBD> ModificarCliente(Cliente _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID  },
                { "@Nombre", _cliente.Nombre.Trim().ToUpper()  },
                { "@Segundo_nombre", _cliente.Segundo_nombre.Trim().ToUpper() },
                { "@Apellido_paterno", _cliente.Apellido_paterno.Trim().ToUpper()  },
                { "@Apellido_materno", _cliente.Apellido_materno?.Trim().ToUpper()  },
                { "@Fecha_nacimiento", _cliente.Fecha_nacimiento  },
                { "@TipoSexoID", _cliente.TipoSexoID  },
                { "@TipoEstadoCivilID", _cliente.TipoEstadoCivilID },
                { "@CURP", _cliente.CURP.Trim().ToUpper() },
                { "@RFC", _cliente.RFC.Trim().ToUpper() },
                { "@Clave_elector", _cliente.Clave_elector.Trim().ToUpper() },
                { "@Telefono", _cliente.Telefono.Trim().ToLower()  },
                { "@Telefono_prefijo", _cliente.Telefono_prefijo.Trim() },
                { "@Correo_electronico", _cliente.Correo_electronico.Trim().ToLower()},
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Cliente_M_PorModelo", parameters);

            if (dt == null)
                return _resultado;
            else
            {
                _resultado.Error = Convert.ToBoolean(dt["Error"]);
                _resultado.ErrorDesc = dt["ErrorDesc"] != null ? dt["ErrorDesc"].ToString() : "";
                _resultado.Icon = dt["Icon"] != null ? dt["Icon"].ToString() : "";                
                _resultado.Code = 200;
                return _resultado;
#nullable enable
            }
        }
        //Obtiene todos los clientes actuales
        public async Task<List<ClienteDTO>> ObtenerClientes()
        {
            List<ClienteDTO> _lista = new List<ClienteDTO>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_Cliente_O_Todos", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = ClienteDTO.ObtenerListaDesdeTabla(dt);
                return _lista;
            }
        }
        //Obtiene la información de un cliente mediante su ID
        public async Task<Cliente> ObtenerClientePorID(int clienteID)
        {
            Cliente _cliente = new Cliente();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Cliente_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = new Cliente(dt);
                return _cliente;
            }
        }
        //Verifica si el cliente ya existe
        public async Task<ResultadoBD> ValidarDuplicado(Cliente _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@CURP", _cliente.CURP.Trim().ToUpper() },
                { "@ClienteID", _cliente.ClienteID },
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Cliente_O_ValidarDuplicado", parameters);

            if (dt == null)
                return _resultado;
            else
            {
                _resultado.Error = Convert.ToBoolean(dt["Error"]);
                _resultado.ErrorDesc = dt["ErrorDesc"] != null ? dt["ErrorDesc"].ToString() : "";
                _resultado.Icon = dt["Icon"] != null ? dt["Icon"].ToString() : "";
                _resultado.Code = Convert.ToBoolean(dt["Error"]) == true ? 409 : 200;
                return _resultado;
#nullable enable
            }
        }
    }
}
