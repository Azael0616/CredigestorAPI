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
    public class TipoEstadoCivilController : ControllerBase
    {
        private readonly ITipo_estado_civilBLL _tipoEstadoCivilBLL;
        public TipoEstadoCivilController(ITipo_estado_civilBLL tipoEstadoCivilBLL)
        {
            _tipoEstadoCivilBLL = tipoEstadoCivilBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene el catalogo de tipo de estado civil")]
        [HttpGet("ObtenerCatalogoActivo")]
        public async Task<IActionResult> ObtenerCatalogoActivo()
        {
            try
            {
                List<Tipo_estado_civil> _lista = await _tipoEstadoCivilBLL.ObtenerCatalogoActivo();
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
