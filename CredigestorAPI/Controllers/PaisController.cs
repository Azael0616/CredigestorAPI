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
    public class PaisController : ControllerBase
    {
        private readonly IPaisBLL _paisBLL;        
        public PaisController(IPaisBLL paisBLL)
        {
            _paisBLL = paisBLL; 
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene un catálogo con los paises activos")]
        [HttpGet("ObtenerCatalogoActivo")]
        public async Task<IActionResult> ObtenerCatalogoActivo()
        {
            try
            {
                List<Pais> _lista = await _paisBLL.ObtenerCatalogoActivo();
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
