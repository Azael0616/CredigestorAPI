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
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioBLL _municipioBLL;
        public MunicipioController(IMunicipioBLL municipioBLL)
        {
            _municipioBLL = municipioBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene un catálogo con los municipios activos a partir del ID del estado")]
        [HttpGet("ObtenerCatalogoActivo/{estadoID}")]
        public async Task<IActionResult> ObtenerCatalogoActivo(int estadoID)
        {
            try
            {
                List<Municipio> _lista = await _municipioBLL.ObtenerCatalogoActivo(estadoID);
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
