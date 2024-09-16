using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Innov8Tech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteAplicationService _clienteAplicationService;


        public ClienteController(IClienteAplicationService clienteAplicationService)
        {
            _clienteAplicationService = clienteAplicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<ClienteEntity>>]
        public IActionResult Get()
        {
            var clientes = _clienteAplicationService.GetAll();
            if (clientes == null)
            {
                return NotFound("Nao foi possivel encontrar clientes");
            }
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        [Produces<ClienteEntity>]
        public IActionResult Get(int id)
        {
            var cliente = _clienteAplicationService.GetById(id);
            if (cliente == null)
            {
                return NotFound("Nao foi possivel encontrar cliente");
            }
            return Ok(cliente);
        }
        [HttpPost]
        [Produces<ClienteEntity>]
        public IActionResult Post([FromBody] ClienteEntity cliente)
        {
            var clienteInserido = _clienteAplicationService.Insert(cliente);
            if (clienteInserido == null)
            {
                return BadRequest("Nao foi possivel inserir cliente");
            }
            return Ok(clienteInserido);
        }

        [HttpPut("{id}")]
        [Produces<ClienteEntity>]
           public IActionResult Put([FromBody] ClienteEntity cliente)
        {
            var clienteAtualizado = _clienteAplicationService.Update(cliente);
            if (clienteAtualizado == null)
            {
                return BadRequest("Nao foi possivel atualizar cliente");
            }
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        [Produces<ClienteEntity>]
       public IActionResult Delete(int id)
        {
            _clienteAplicationService.Delete(id);
            return Ok();
        }


       
    }
}
