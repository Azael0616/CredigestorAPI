using CredigestorAPI.BLL;
using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CredigestorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBLL _clienteBLL;
        public ClienteController(IClienteBLL clienteBLL)
        {
            _clienteBLL = clienteBLL;
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene todos los clientes actuales")]
        [HttpGet("ObtenerClientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            try
            {
                List<ClienteDTO> _lista = await _clienteBLL.ObtenerClientes();
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la información de un cliente a partir de su ID")]
        [HttpGet("ObtenerCliente/{clienteID}")]
        public async Task<IActionResult> ObtenerCliente(int clienteID)
        {
            try
            {
                Cliente _cliente = await _clienteBLL.ObtenerClientePorID(clienteID);
                return StatusCode(200, _cliente);
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta un cliente, recibiendo como parámetro el modelo")]
        [HttpPost("InsertarCliente")]
        public async Task<IActionResult> InsertarCliente([FromBody] Cliente _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarCliente(_cliente, usuarioID);
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica un cliente, recibiendo como parámetro el modelo")]
        [HttpPost("ModificarCliente")]
        public async Task<IActionResult> ModificarCliente([FromBody] Cliente _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarCliente(_cliente, usuarioID);
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
