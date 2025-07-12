using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CredigestorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NivelUsuarioController : Controller
    {
        private readonly INivel_usuarioBLL _nivelUsuarioBLL;        
        public NivelUsuarioController(INivel_usuarioBLL nivelUsuarioBLL)
        {
            _nivelUsuarioBLL = nivelUsuarioBLL;            
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene los tipos de nivel de usuario activos según el UsuarioID del JWT")]
        [HttpGet("ObtenerCatalogoActivo")]
        public async Task<IActionResult> ObtenerCatalogoActivo()
        {
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                List<Nivel_usuario> _lista = await _nivelUsuarioBLL.ObtenerCatalogoActivo(usuarioID);
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
    }
}
