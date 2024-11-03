using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Innov8Tech.Controllers
{
    [Route("api/ramos")]
    [ApiController]
    public class RamoController : Controller
    {
        private readonly IRamoAplicationService _ramoAplicationService;

        public RamoController(IRamoAplicationService ramoAplicationService)
        {
            _ramoAplicationService = ramoAplicationService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<RamoEntity>))]
        public IActionResult Get()
        {
            var ramos = _ramoAplicationService.GetAll();
            if (ramos == null)
            {
                return NotFound("Não foi possível encontrar ramos");
            }
            return Ok(ramos);
        }

        [HttpGet("{id}")]
        [Produces(typeof(RamoEntity))]
        public IActionResult Get(int id)
        {
            var ramo = _ramoAplicationService.GetById(id);
            if (ramo == null)
            {
                return NotFound("Não foi possível encontrar o ramo");
            }
            return Ok(ramo);
        }

        [HttpPost]
        [Produces(typeof(RamoEntity))]
        public IActionResult Post([FromBody] RamoEntity ramo)
        {
            var ramoInserido = _ramoAplicationService.Insert(ramo);
            if (ramoInserido == null)
            {
                return BadRequest("Não foi possível inserir o ramo");
            }
            return Ok(ramoInserido);
        }

        [HttpPut("{id}")]
        [Produces(typeof(RamoEntity))]
        public IActionResult Put(int id, [FromBody] RamoEntity ramo)
        {
            ramo.Id = id; // Certificando-se de que o ID do corpo corresponde ao ID da rota
            var ramoAtualizado = _ramoAplicationService.Update(ramo);
            if (ramoAtualizado == null)
            {
                return BadRequest("Não foi possível atualizar o ramo");
            }
            return Ok(ramoAtualizado);
        }

        [HttpDelete("{id}")]
        [Produces(typeof(RamoEntity))]
        public IActionResult Delete(int id)
        {
            var result = _ramoAplicationService.Delete(id);
            if (!result)
            {
                return BadRequest("Não foi possível deletar o ramo");
            }
            return Ok("Ramo deletado com sucesso");
        }
    }
}
