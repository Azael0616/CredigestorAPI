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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta un cliente, recibiendo como parámetro el modelo Cliente")]
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
        [SwaggerOperation(Summary = "Modifica un cliente, recibiendo como parámetro el modelo Cliente")]
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta la direccion del cliente, recibiendo como parámetro el modelo Cliente_direccion")]
        [HttpPost("InsertarClienteDireccion")]
        public async Task<IActionResult> InsertarClienteDireccion([FromBody] Cliente_direccion _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarClienteDireccion(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica la direccion del cliente, recibiendo como parámetro el modelo Cliente_direccion")]
        [HttpPost("ModificarClienteDireccion")]
        public async Task<IActionResult> ModificarClienteDireccion([FromBody] Cliente_direccion _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarClienteDireccion(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta un documento del cliente, recibiendo como parámetro el modelo Cliente_documento")]
        [HttpPost("InsertarClienteDocumento")]
        public async Task<IActionResult> InsertarClienteDocumento([FromBody] Cliente_documento _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarClienteDocumento(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica un documento del cliente, recibiendo como parámetro el modelo Cliente_documento")]
        [HttpPost("ModificarClienteDocumento")]
        public async Task<IActionResult> ModificarClienteDocumento([FromBody] Cliente_documento _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarClienteDocumento(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta el historial previo del cliente, recibiendo como parámetro el modelo Cliente_historial_previo")]
        [HttpPost("InsertarClienteHistorialPrevio")]
        public async Task<IActionResult> InsertarClienteHistorialPrevio([FromBody] Cliente_historial_previo _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarClienteHistorialPrevio(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica el historial previo del cliente, recibiendo como parámetro el modelo Cliente_historial_previo")]
        [HttpPost("ModificarClienteHistorialPrevio")]
        public async Task<IActionResult> ModificarClienteHistorialPrevio([FromBody] Cliente_historial_previo _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarClienteHistorialPrevio(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta el perfil del cliente, recibiendo como parámetro el modelo Cliente_perfil")]
        [HttpPost("InsertarClientePerfil")]
        public async Task<IActionResult> InsertarClientePerfil([FromBody] Cliente_perfil _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarClientePerfil(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica el perfil del cliente, recibiendo como parámetro el modelo Cliente_perfil")]
        [HttpPost("ModificarClientePerfil")]
        public async Task<IActionResult> ModificarClientePerfil([FromBody] Cliente_perfil _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarClientePerfil(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Inserta la referencia del cliente, recibiendo como parámetro el modelo Cliente_referencia")]
        [HttpPost("InsertarClienteReferencia")]
        public async Task<IActionResult> InsertarClienteReferencia([FromBody] Cliente_referencia _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.InsertarClienteReferencia(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Modifica la referencia del cliente, recibiendo como parámetro el modelo Cliente_referencia")]
        [HttpPost("ModificarClienteReferencia")]
        public async Task<IActionResult> ModificarClienteReferencia([FromBody] Cliente_referencia _cliente)
        {
            ResultadoBD _resultado = new ResultadoBD();
            //Se crea try catch
            try
            {
#nullable disable
                int usuarioID = int.Parse(User.FindFirst("UsuarioID")?.Value); // Esto viene del Claims y obtiene el usuarioID
#nullable enable
                _resultado = await _clienteBLL.ModificarClienteReferencia(_cliente, usuarioID);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la información de un cliente a partir de su ID")]
        [HttpGet("ObtenerClientePorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClientePorID(int clienteID)
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la dirección de un cliente a partir de su ID")]
        [HttpGet("ObtenerClienteDireccionPorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClienteDireccionPorID(int clienteID)
        {
            try
            {
                Cliente_direccion _cliente = await _clienteBLL.ObtenerClienteDireccionPorID(clienteID);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene los documentos de un cliente a partir de su ID")]
        [HttpGet("ObtenerClienteDocumentoPorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClienteDocumentoPorID(int clienteID)
        {
            try
            {
                List<Cliente_documento> _cliente = await _clienteBLL.ObtenerClienteDocumentoPorID(clienteID);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene el historial previo de un cliente a partir de su ID")]
        [HttpGet("ObtenerClienteHistorialPrevioPorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClienteHistorialPrevioPorID(int clienteID)
        {
            try
            {
                Cliente_historial_previo _cliente = await _clienteBLL.ObtenerClienteHistorialPrevioPorID(clienteID);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene el perfil de un cliente a partir de su ID")]
        [HttpGet("ObtenerClientePerfilPorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClientePerfilPorID(int clienteID)
        {
            try
            {
                Cliente_perfil _cliente = await _clienteBLL.ObtenerClientePerfilPorID(clienteID);
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene las referencias de un cliente a partir de su ID")]
        [HttpGet("ObtenerClienteReferenciaPorID/{clienteID}")]
        public async Task<IActionResult> ObtenerClienteReferenciaPorID(int clienteID)
        {
            try
            {
                List<Cliente_referencia> _cliente = await _clienteBLL.ObtenerClienteReferenciaPorID(clienteID);
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
    }
}
