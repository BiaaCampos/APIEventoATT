using DDD.Domain.GeralContext;
using ApplicationServiceVenda;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        readonly AppServiceVenda _vendaAppService;
        readonly IVendaRepository _vendaRepository;

        public VendaController(AppServiceVenda vendaAppService, IVendaRepository vendaRepository)
        {
            _vendaAppService = vendaAppService;
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        public ActionResult<List<Venda>> Get()
        {
            return Ok(_vendaRepository.GetVendas());
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> GetById(int id)
        {
            return Ok(_vendaRepository.GetVendaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Venda> CreateVenda(int idComprador,int idEvento, int qntdIng)
        {
            var gerandoVenda = _vendaAppService.GerarVenda(idComprador, idEvento, qntdIng);


            return CreatedAtAction(nameof(GetById), new { id = gerandoVenda.VendaId }, gerandoVenda);
        }
    }
}
