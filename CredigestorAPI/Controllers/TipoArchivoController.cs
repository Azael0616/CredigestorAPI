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
    public class TipoArchivoController : ControllerBase
    {
        private readonly ITipo_archivoBLL _tipoArchivoBLL;
        public TipoArchivoController(ITipo_archivoBLL tipoArchivoBLL)
        {
            _tipoArchivoBLL = tipoArchivoBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los tipo de archivo activo")]
        [HttpGet("ObtenerCatalogoActivo")]
        public async Task<IActionResult> ObtenerCatalogoActivo()
        {
            try
            {
                List<Tipo_archivo> _lista = await _tipoArchivoBLL.ObtenerCatalogoActivo();
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
