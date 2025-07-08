using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
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
        [HttpGet("Prueba")]
        public IActionResult Prueba()
        {
            return Ok("Endpoint de prueba en el controlador de Usuario");
        }
        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario(Usuario _usuario)
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
