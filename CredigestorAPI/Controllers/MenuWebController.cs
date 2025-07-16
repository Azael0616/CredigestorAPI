using CredigestorAPI.BLL;
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
    public class MenuWebController : ControllerBase
    {
        private readonly IMenu_webBLL _menuWebBLL;
        public MenuWebController(IMenu_webBLL menuWebBLL)
        {
            _menuWebBLL = menuWebBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene los menu web disponible para un usuario según su nivel de usuario")]
        [HttpGet("ObtenerMenuWebPorUsuario")]
        public async Task<IActionResult> ObtenerMenuWebPorUsuario()
        {
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                List<Menu_web> _lista = await _menuWebBLL.ObtenerMenuWebPorUsuario(usuarioID);
                List<Menu_web> _listaArbol = Utils.Utils.ConstruirJerarquia(_lista);
                return StatusCode(200, _listaArbol);
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
