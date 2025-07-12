using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;
using System.Data;
namespace CredigestorAPI.DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public UsuarioDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Inserta la información de un usuario
        public async Task<ResultadoBD> InsertarUsuario(Usuario _usuario)
        {
            ResultadoBD _resultado = new ResultadoBD();

#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@Nombre_usuario", _usuario.Nombre_usuario.Trim().ToUpper()  },
                { "@PasswordHash", _usuario.PasswordHash },
                { "@Nombre", _usuario.Nombre.Trim().ToUpper()  },
                { "@Segundo_nombre", _usuario.Segundo_nombre?.Trim().ToUpper()  },
                { "@Apellido_paterno", _usuario.Apellido_paterno.Trim().ToUpper()  },
                { "@Apellido_materno", _usuario.Apellido_materno.Trim().ToUpper()  },
                { "@Fecha_nacimiento", _usuario.Fecha_nacimiento },
                { "@Fecha_ingreso", _usuario.Fecha_ingreso },
                { "@Telefono", _usuario.Telefono?.Trim()  },
                { "@Telefono_prefijo", _usuario.Telefono_prefijo?.Trim() },
                { "@Correo_electronico", _usuario.Correo_electronico.Trim().ToLower()  },                
                { "@NivelUsuarioID", _usuario.NivelUsuarioID }                                
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Usuario_I_PorModelo", parameters);

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
        //Verifica si el usuario ya existe
        public async Task<ResultadoBD> ValidarDuplicado(Usuario _usuario)
        {
            ResultadoBD _resultado = new ResultadoBD();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@Nombre_usuario", _usuario.Nombre_usuario.Trim().ToUpper() },
            };

            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Usuario_O_ValidarDuplicado", parameters);

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
        //Obtiene todos los usuarios actuales
        public async Task<List<UsuarioDTO>> ObtenerUsuarios()
        {
            List<UsuarioDTO> _lista = new List<UsuarioDTO>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_Usuario_O_Todos", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = UsuarioDTO.ObtenerListaDesdeTabla(dt);
                return _lista;
            }
        }
        //Obtiene el nombre de usuario y contraseña
        public async Task<UsuarioEncontrado> ObtenerUsuarioPorNombreUsuario(UsuarioLogin _usuario)
        {
            UsuarioEncontrado _usuarioLogin = new UsuarioEncontrado();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@Nombre_usuario", _usuario.Nombre_usuario},
            };
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Usuario_O_PorNombreUsuario", parameters);
            if(dt == null)
            {
                throw new HttpResponseException(500, "Error interno del servidor","error");
            }
            else
            {
                //En caso no haya encontrado al usuario
                if(Convert.ToBoolean(dt["Error"]))
                {
                    throw new HttpResponseException(404, dt["ErrorDesc"].ToString(), dt["Icon"].ToString());
                }
                else
                {
                    _usuarioLogin = new UsuarioEncontrado(dt);   
                }
            }
#nullable enable
            return _usuarioLogin;
        }
        //Obtiene los datos para crear el usuario de sesión
        public async Task<UsuarioSesion> ObtenerUsuarioSesion(int usuarioID)
        {
            UsuarioSesion _usuarioSesion = new UsuarioSesion();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@UsuarioID", usuarioID },
            };
            DataRow dt = await _sqlAuxiliar.EjecutarPrimeraFilaPA("Sp_Usuario_O_Sesion", parameters);
            if (dt == null)
            {
                throw new HttpResponseException(500, "Error interno del servidor", "error");
            }
            else
            {
                _usuarioSesion = new UsuarioSesion(dt);
            }
#nullable enable
            return _usuarioSesion;
        }
    }
}
