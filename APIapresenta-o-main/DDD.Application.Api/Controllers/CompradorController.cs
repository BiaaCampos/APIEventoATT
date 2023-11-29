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


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comprador comprador)
        {
            try
            {
                if (comprador == null || id != comprador.Id)
                    return BadRequest("Invalid request data. Please check the request body and parameters.");

                var existingComprador = _compradorRepository.GetCompradorById(id);

                if (existingComprador == null)
                {
                    // Log that the Comprador was not found
                    Console.WriteLine($"Comprador with id {id} not found.");
                    return NotFound("Comprador not found.");
                }

                _compradorRepository.UpdateComprador(comprador);

                // Log the successful update
                Console.WriteLine($"Comprador with id {id} updated successfully.");

                return Ok("Comprador updated successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                Console.WriteLine($"Error in PUT request: {ex.Message}");

                // Return a more informative error message in the response body
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request. Please try again.");
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

