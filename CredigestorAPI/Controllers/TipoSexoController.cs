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
    public class TipoSexoController : ControllerBase
    {
        private readonly ITipo_sexoBLL _tipoSexoBLL;
        public TipoSexoController(ITipo_sexoBLL tipoSexoBLL)
        {
            _tipoSexoBLL = tipoSexoBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene el catalogo de tipo de sexo")]
        [HttpGet("ObtenerCatalogoActivo")]
        public async Task<IActionResult> ObtenerCatalogoActivo()
        {
            try
            {
                List<Tipo_sexo> _lista = await _tipoSexoBLL.ObtenerCatalogoActivo();
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
