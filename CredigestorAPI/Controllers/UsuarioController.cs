using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CredigestorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;
        public UsuarioController(IUsuarioBLL usuarioBLL)
        {
            _usuarioBLL = usuarioBLL;
        }
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
        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario([FromBody] Usuario _usuario)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
                _resultado = await _usuarioBLL.InsertarUsuario(_usuario);
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
    }
}
