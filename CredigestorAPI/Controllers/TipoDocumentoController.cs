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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipo_documentoBLL _tipoDocumentoBLL;
        public TipoDocumentoController(ITipo_documentoBLL tipoDocumentoBLL)
        {
            _tipoDocumentoBLL = tipoDocumentoBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los tipo de documento activo")]
        [HttpGet("ObtenerCatalogoActivo/{formularioID}")]
        public async Task<IActionResult> ObtenerCatalogoActivo(int formularioID)
        {
            try
            {
                List<Tipo_documento> _lista = await _tipoDocumentoBLL.ObtenerCatalogoActivo(formularioID);
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
