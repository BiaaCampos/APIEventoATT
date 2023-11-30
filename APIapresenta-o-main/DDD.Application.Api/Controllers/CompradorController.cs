using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        readonly ICompradorRepository _compradorRepository;

        public CompradorController(ICompradorRepository compradorRepository)
        {
            _compradorRepository = compradorRepository;
        }

        // GET: api/<CompradorController>
        [HttpGet]
        public ActionResult<List<Comprador>> Get()
        {
            return Ok(_compradorRepository.GetComprador());
        }

        // GET api/<CompradorController>/5
        [HttpGet("{id}")]
        public ActionResult<Comprador> GetById(int id)
        {
            return Ok(_compradorRepository.GetCompradorById(id));
        }

        // POST api/<CompradorController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Comprador> CreateComprador(Comprador comprador)
        {
            _compradorRepository.InsertComprador(comprador);
            return CreatedAtAction(nameof(GetById), new { id = comprador.Id }, comprador);
        }


        [HttpPut]
        public ActionResult Put([FromBody] Comprador comprador)
        {
            try
            {

                if (comprador.Id == null)
                {
                    Console.WriteLine($"Comprador nao encontrado.");
                    return NotFound("Comprador nao encontrado.");
                }

                _compradorRepository.UpdateComprador(comprador);

                return Ok("Comprador Encontrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // DELETE api/<CompradorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var comprador = _compradorRepository.GetCompradorById(id);

                if (comprador == null)
                    return NotFound();

                _compradorRepository.DeleteComprador(comprador);
                return Ok("Comprador Excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

