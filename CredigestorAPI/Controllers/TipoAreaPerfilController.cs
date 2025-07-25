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
    public class TipoAreaPerfilController : ControllerBase
    {
        private readonly ITipo_area_perfilBLL _tipoAreaPerfilBLL;
        public TipoAreaPerfilController(ITipo_area_perfilBLL tipoAreaPerfilBLL)
        {
            _tipoAreaPerfilBLL = tipoAreaPerfilBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los tipo de area de perfil para estudio activos")]
        [HttpGet("ObtenerCatalogoActivoEstudio")]
        public async Task<IActionResult> ObtenerCatalogoActivoEstudio()
        {
            try
            {
                List<Tipo_area_perfil> _lista = await _tipoAreaPerfilBLL.ObtenerCatalogoActivoEstudio();
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los tipo de area de perfil para ocupación activos")]
        [HttpGet("ObtenerCatalogoActivoOcupacion")]
        public async Task<IActionResult> ObtenerCatalogoActivoOcupacion()
        {
            try
            {
                List<Tipo_area_perfil> _lista = await _tipoAreaPerfilBLL.ObtenerCatalogoActivoOcupacion();
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
