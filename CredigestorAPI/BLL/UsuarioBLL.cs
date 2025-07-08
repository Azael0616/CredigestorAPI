using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioDAL _usuarioDAL;
        private readonly IUsuarioUtils _usuarioUtils;
        public UsuarioBLL(IUsuarioDAL usuarioDAL, IUsuarioUtils usuarioUtils)
        {
            _usuarioDAL = usuarioDAL;
            _usuarioUtils = usuarioUtils;
        }
        public async Task<ResultadoBD> InsertarUsuario(Usuario _usuario)
        {
            #region Validaciones
            //Validar si el nombre de usuario es nulo o menor a 10 caracteres
            if (string.IsNullOrWhiteSpace(_usuario.Nombre_usuario) || _usuario.Nombre_usuario?.Trim().Length != 10)
            {
                throw new HttpResponseException(400, "El nombre de usuario debe ser a 10 carácteres");
            }
            //Validar si el nombre de usuario existe
            ResultadoBD _validacion = await _usuarioDAL.ValidarDuplicado(_usuario);
            if (_validacion.Error)
            {
                throw new HttpResponseException(409, "Nombre de usuario duplicado");
            }
            //Validar contraseña segura
            if (!_usuarioUtils.ValidarPasswordSegura(_usuario.PasswordHash))
            {
                throw new HttpResponseException(400, "La contraseña no es segura");
            }
            else
            {
                //Se crea el hash de la contraseña
                _usuario.PasswordHash = _usuarioUtils.HashPassword(_usuario,_usuario.PasswordHash); 
            }
            //Validar el nombre
            if (string.IsNullOrWhiteSpace(_usuario.Nombre) || _usuario.Nombre?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El nombre no tiene la sintaxis correcta");
            }
            //Validar el segundo nombre
            if (_usuario.Segundo_nombre?.Length > 64)
            {
                throw new HttpResponseException(400, "El segundo nombre no tiene la sintaxis correcta");
            }
            //Validar el apellido paterno
            if (string.IsNullOrWhiteSpace(_usuario.Apellido_paterno) || _usuario.Apellido_paterno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido paterno no tiene la sintaxis correcta");
            }
            //Validar el apellido materno
            if (string.IsNullOrWhiteSpace(_usuario.Apellido_materno) || _usuario.Apellido_materno?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El apellido materno no tiene la sintaxis correcta");
            }
            //Validar la fecha de nacimiento
            if(_usuarioUtils.CalcularEdad(_usuario.Fecha_nacimiento) < 18)
            {
                throw new HttpResponseException(400, "La fecha de nacimiento no tiene la sintaxis correcta");
            }
            //Validar la fecha de ingreso
            if(!_usuarioUtils.ValidarFechaIngreso(_usuario.Fecha_ingreso))
            {
                throw new HttpResponseException(400, "La fecha de ingreso no tiene la sintaxis correcta");
            }
            //Validar el teléfono
            if (!string.IsNullOrWhiteSpace(_usuario.Telefono) && _usuario.Telefono?.Trim().Length != 10)
            {
                throw new HttpResponseException(400, "El teléfono no tiene la sintaxis correcta");
            }
            //Validar el prefijo del telefono
            if (!string.IsNullOrWhiteSpace(_usuario.Telefono_prefijo) && _usuario.Telefono_prefijo?.Trim().Length > 3)
            {
                throw new HttpResponseException(400, "El prefijo del teléfono no tiene la sintaxis correcta");
            }
            //Validar el correo
            if (!_usuarioUtils.ValidarCorreo(_usuario.Correo_electronico) || _usuario.Correo_electronico?.Trim().Length > 64)
            {
                throw new HttpResponseException(400, "El correo electrónico no tiene la sintaxis correcta");
            }
            //Validar el nivel de usuario
            if(_usuario.NivelUsuarioID <= 0)
            {
                throw new HttpResponseException(400, "El nivel de usuario no tiene la sintaxis correcta");
            }
            #endregion

            ResultadoBD _resultado = await _usuarioDAL.InsertarUsuario(_usuario);
            return _resultado;
        }
    }
}
