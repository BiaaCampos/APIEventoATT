using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        readonly IEventosRepository _eventosRepository;

        public EventoController(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        // GET: api/<EventosController>


        [HttpGet]
        public ActionResult<List<Eventos>> Get()
        {
            return Ok(_eventosRepository.GetEventos());
        }

        [HttpGet("{id}")]
        public ActionResult<Eventos> GetById(int id)
        {
            return Ok(_eventosRepository.GetEventosById(id));
        }

        [HttpGet("GetByName/{nome}")]
        public ActionResult<List<Eventos>> GetPeloNome(string nome)
        {
            return Ok(_eventosRepository.GetPorNome(nome));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Eventos> CreateEvento(Eventos eventos)
        {
            if (eventos.NomeEvento.Length < 3 || eventos.NomeEvento.Length > 30)
            {
                return BadRequest("Nome do Evento deve ser maior que 3 e menor que 30 caracteres.");
            }
            _eventosRepository.InsertEventos(eventos);
            return CreatedAtAction(nameof(GetById), new { id = eventos.EventosId }, eventos);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Eventos eventos)
        {
            try
            {
                if (eventos == null)
                    return NotFound();

                _eventosRepository.UpdateEventos(eventos);
                return Ok("Evento Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Eventos eventos)
        {
            try
            {
                if (eventos == null)
                    return NotFound();

                _eventosRepository.DeleteEventos(eventos);
                return Ok("Evento Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}