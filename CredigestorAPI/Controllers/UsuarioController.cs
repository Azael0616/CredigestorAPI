using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CredigestorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;
        private readonly IConfiguration _config;
        public UsuarioController(IUsuarioBLL usuarioBLL, IConfiguration config)
        {
            _usuarioBLL = usuarioBLL;
            _config = config;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los usuarios actuales")]
        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                List<UsuarioDTO> _lista = await _usuarioBLL.ObtenerUsuarios();
                return StatusCode(200, _lista);
            }
            catch (HttpResponseException ex)
            {
                ResultadoBD _resultado = new ResultadoBD();
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }            
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la información de un usuario a partir de su ID")]
        [HttpGet("ObtenerUsuario/{usuarioID}")]
        public async Task<IActionResult> ObtenerUsuario(int usuarioID)
        {
            try
            {
                Usuario _usuario = await _usuarioBLL.ObtenerUsuarioPorID(usuarioID);
                return StatusCode(200, _usuario);
            }
            catch (HttpResponseException ex)
            {
                ResultadoBD _resultado = new ResultadoBD();
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica un usuario, recibiendo como parámetro el modelo")]
        [HttpPost("ModificarUsuario")]
        public async Task<IActionResult> ModificarUsuario([FromBody] Usuario _usuario)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _usuarioBLL.ModificarUsuario(_usuario, usuarioID);
                return StatusCode(200, _resultado);
            }
            catch (HttpResponseException ex)
            {
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta un usuario, recibiendo como parámetro el modelo")]
        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario([FromBody] Usuario _usuario)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _usuarioBLL.InsertarUsuario(_usuario, usuarioID);
                return StatusCode(200, _resultado);
            }
            catch (HttpResponseException ex)
            {
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }
        }
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Retorna un token JWT, recibiendo como parámetro el modelo UsuarioLogin")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin _usuario)
        {
            try
            {
                string token = await _usuarioBLL.ObtenerToken(_usuario,_config);
                return StatusCode(200, new { token=token });
            }
            catch (HttpResponseException ex)
            {
                ResultadoBD _resultado = new ResultadoBD();
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene los datos del usuario que ha iniciado sesión")]
        [HttpGet("ObtenerUsuarioSesion")]
        public async Task<IActionResult> ObtenerUsuarioSesion()
        {
            UsuarioSesion _usuarioSesion = new UsuarioSesion();
            //Se crea try catch
            try
            {
#nullable disable

                // Delegado. nombre = User.Identity.Name; Esto viene del ClaimTypes.Name y obtiene el nombre de usuario
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
                _usuarioSesion = await _usuarioBLL.ObtenerUsuarioSesion(usuarioID);
#nullable enable
                return StatusCode(200, _usuarioSesion);
            }
            catch (HttpResponseException ex)
            {
                ResultadoBD _resultado = new ResultadoBD();
                _resultado.ErrorDesc = ex.Mensaje;
                _resultado.Icon = ex.Icono;
                _resultado.Code = ex.Codigo;
                return StatusCode(ex.Codigo, _resultado);
            }
        }
    }
}
