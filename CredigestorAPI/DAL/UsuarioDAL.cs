using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
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
                _resultado.Code = 200;
                return _resultado;
#nullable enable
            }
        }
    }
}
