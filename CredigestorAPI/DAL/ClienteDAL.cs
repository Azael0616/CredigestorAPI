using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.DAL.Mappers.DTO;
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
        //Inserta la información principal de un cliente
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
        //Modifica la información principal de un cliente
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
        //Inserta la información del domicilio de un cliente
        public async Task<ResultadoBD> InsertarClienteDireccion(Cliente_direccion _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@Calle", _cliente.Calle.Trim().ToUpper() },                
                { "@Numero_exterior", _cliente.Numero_exterior?.Trim().ToUpper()  },
                { "@Numero_interior", _cliente.Numero_interior?.Trim().ToUpper()  },
                { "@Entre_calle1", _cliente.Entre_calle1?.Trim().ToUpper()  },
                { "@Entre_calle2", _cliente.Entre_calle2?.Trim().ToUpper()  },                
                { "@Colonia", _cliente.Colonia.Trim().ToUpper() },
                { "@PaisID", _cliente.PaisID },
                { "@EstadoID", _cliente.EstadoID  },
                { "@MunicipioID", _cliente.MunicipioID },
                { "@Referencia_casa", _cliente.Referencia_casa?.Trim().ToUpper()},
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteDireccion_I_PorModelo", parameters);

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
        //Modifica la información del domicilio de un cliente
        public async Task<ResultadoBD> ModificarClienteDireccion(Cliente_direccion _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@Calle", _cliente.Calle.Trim().ToUpper() },
                { "@Numero_exterior", _cliente.Numero_exterior?.Trim().ToUpper()  },
                { "@Numero_interior", _cliente.Numero_interior?.Trim().ToUpper()  },
                { "@Entre_calle1", _cliente.Entre_calle1?.Trim().ToUpper()  },
                { "@Entre_calle2", _cliente.Entre_calle2?.Trim().ToUpper()  },
                { "@Colonia", _cliente.Colonia.Trim().ToUpper() },
                { "@PaisID", _cliente.PaisID },
                { "@EstadoID", _cliente.EstadoID  },
                { "@MunicipioID", _cliente.MunicipioID },
                { "@Referencia_casa", _cliente.Referencia_casa?.Trim().ToUpper()},
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteDireccion_M_PorModelo", parameters);

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
        //Inserta la información de los documentos de cliente
        public async Task<ResultadoBD> InsertarClienteDocumento(Cliente_documento _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@TipoDocumentoID", _cliente.TipoDocumentoID },
                { "@Contenido", _cliente.Contenido  },
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteDocumento_I_PorModelo", parameters);

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
        //Modifica la información de los documentos de cliente
        public async Task<ResultadoBD> ModificarClienteDocumento(Cliente_documento _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@DocumentoID", _cliente.DocumentoID },
                { "@ClienteID", _cliente.ClienteID },
                { "@TipoDocumentoID", _cliente.TipoDocumentoID },
                { "@Contenido", _cliente.Contenido  },
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteDocumento_M_PorModelo", parameters);

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
        //Inserta la información del historial crediticio del cliente
        public async Task<ResultadoBD> InsertarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@TCA", _cliente.Total_creditos_anteriores  },
                { "@TCL", _cliente.Total_creditos_liquidados  },
                { "@TCM", _cliente.Total_creditos_mora  },
                { "@Tiene_comprobantes", _cliente.Tiene_comprobantes  },
                { "@Comprobante", _cliente.Comprobante_digitalizado  },
                { "@TipoDocumentoID", _cliente.TipoDocumentoID },
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteHistorialPrevio_I_PorModelo", parameters);

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
        //Modifica la información del historial crediticio de cliente
        public async Task<ResultadoBD> ModificarClienteHistorialPrevio(Cliente_historial_previo _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@TCA", _cliente.Total_creditos_anteriores  },
                { "@TCL", _cliente.Total_creditos_liquidados  },
                { "@TCM", _cliente.Total_creditos_mora  },
                { "@Tiene_comprobantes", _cliente.Tiene_comprobantes  },
                { "@Comprobante", _cliente.Comprobante_digitalizado  },
                { "@TipoDocumentoID", _cliente.TipoDocumentoID },
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteHistorialPrevio_M_PorModelo", parameters);

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
        //Inserta la información del perfil del cliente
        public async Task<ResultadoBD> InsertarClientePerfil(Cliente_perfil _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@Nivel_estudio", _cliente.Nivel_estudio  },
                { "@Area_estudio", _cliente.Area_estudio  },
                { "@Carrera_estudio", _cliente.Carrera_estudio?.Trim().ToUpper()  },
                { "@Area_ocupacion", _cliente.Area_ocupacion  },
                { "@Puesto", _cliente.Puesto?.Trim().ToUpper()  },
                { "@Empresa", _cliente.Empresa?.Trim().ToUpper()  },
                { "@Tiempo_empresa", _cliente.Tiempo_empresa  },
                { "@Ingreso_mensual", _cliente.Ingreso_mensual  },
                { "@Gasto_mensual", _cliente.Gasto_mensual },
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClientePerfil_I_PorModelo", parameters);

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
        //Modifica la información del perfil del cliente
        public async Task<ResultadoBD> ModificarClientePerfil(Cliente_perfil _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },
                { "@Nivel_estudio", _cliente.Nivel_estudio  },
                { "@Area_estudio", _cliente.Area_estudio  },
                { "@Carrera_estudio", _cliente.Carrera_estudio?.Trim().ToUpper()  },
                { "@Area_ocupacion", _cliente.Area_ocupacion  },
                { "@Puesto", _cliente.Puesto?.Trim().ToUpper()  },
                { "@Empresa", _cliente.Empresa?.Trim().ToUpper()  },
                { "@Tiempo_empresa", _cliente.Tiempo_empresa  },
                { "@Ingreso_mensual", _cliente.Ingreso_mensual  },
                { "@Gasto_mensual", _cliente.Gasto_mensual },
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClientePerfil_M_PorModelo", parameters);

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
        //Inserta la información de la referencia de cliente
        public async Task<ResultadoBD> InsertarClienteReferencia(Cliente_referencia _cliente, int usuarioInsercion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", _cliente.ClienteID },                
                { "@Nombre_completo", _cliente.Nombre_completo?.Trim().ToUpper()  },
                { "@Telefono_referencia", _cliente.Telefono_referencia?.Trim().ToUpper()  },
                { "@Telefono_referencia_prefijo", _cliente.Telefono_referencia_prefijo?.Trim().ToUpper()  },
                { "@Correo_electronico", _cliente.Correo_electronico?.Trim().ToUpper()  },                
                { "@UsuarioID_insercion", usuarioInsercion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteReferencia_I_PorModelo", parameters);

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
        //Modifica la información de la referencia de cliente
        public async Task<ResultadoBD> ModificarClienteReferencia(Cliente_referencia _cliente, int usuarioModificacion)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ReferenciaID", _cliente.ReferenciaID },
                { "@ClienteID", _cliente.ClienteID },
                { "@Nombre_completo", _cliente.Nombre_completo?.Trim().ToUpper()  },
                { "@Telefono_referencia", _cliente.Telefono_referencia?.Trim().ToUpper()  },
                { "@Telefono_referencia_prefijo", _cliente.Telefono_referencia_prefijo?.Trim().ToUpper()  },
                { "@Correo_electronico", _cliente.Correo_electronico?.Trim().ToLower()  },
                { "@UsuarioID_modificacion", usuarioModificacion}
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteReferencia_M_PorModelo", parameters);

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
        //Obtiene la información principal de un cliente mediante su ID
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
                _cliente = ClienteMapper.ObtenerObjetoDataRow(dt);
                return _cliente;
            }
        }
        //Obtiene la información del domicilio de un cliente mediante su ID
        public async Task<Cliente_direccion> ObtenerClienteDireccionPorID(int clienteID)
        {
            Cliente_direccion _cliente = new Cliente_direccion();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteDireccion_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = Cliente_direccionMapper.ObtenerObjetoDataRow(dt);
                return _cliente;
            }
        }
        //Obtiene la información de los documentos de un cliente mediante su ID
        public async Task<List<Cliente_documento>> ObtenerClienteDocumentoPorID(int clienteID)
        {
            List<Cliente_documento> _cliente = new List<Cliente_documento>();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_ClienteDocumento_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = Cliente_documentoMapper.ObtenerListaDataTable(dt);
                return _cliente;
            }
        }
        //Obtiene la información del historial crediticio de un cliente mediante su ID
        public async Task<Cliente_historial_previo> ObtenerClienteHistorialPrevioPorID(int clienteID)
        {
            Cliente_historial_previo _cliente = new Cliente_historial_previo();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClienteHistorialPrevio_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = Cliente_historial_previoMapper.ObtenerObjetoDataRow(dt);
                return _cliente;
            }
        }
        //Obtiene la información del perfil de un cliente mediante su ID
        public async Task<Cliente_perfil> ObtenerClientePerfilPorID(int clienteID)
        {
            Cliente_perfil _cliente = new Cliente_perfil();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_ClientePerfil_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = Cliente_perfilMapper.ObtenerObjetoDataRow(dt);
                return _cliente;
            }
        }
        //Obtiene la información de las referencias de un cliente mediante su ID
        public async Task<List<Cliente_referencia>> ObtenerClienteReferenciaPorID(int clienteID)
        {
            List<Cliente_referencia> _cliente = new List<Cliente_referencia>();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@ClienteID", clienteID},
            };
#nullable enable
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_ClienteReferencia_O_PorID", parameters);
            if (dt == null)
                return _cliente;
            else
            {
                _cliente = Cliente_referenciaMapper.ObtenerListaDataTable(dt);
                return _cliente;
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
                _lista = ClienteDTOMapper.ObtenerListaDataTable(dt);
                return _lista;
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
                { "@RFC", _cliente.RFC.Trim().ToUpper() },
                { "@Clave_elector", _cliente.Clave_elector.Trim().ToUpper() },
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
