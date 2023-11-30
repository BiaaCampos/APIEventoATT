using DDD.Domain.GeralContext;
using DDD.DomainService;

namespace ApplicationServiceVenda
{
    public class AppServiceVenda
    {
        readonly VendaDomainService _vendaDomainService;

        public AppServiceVenda(VendaDomainService vendaDomainService)
        {
            _vendaDomainService = vendaDomainService;
        }
        public Venda GerarVenda(int idComprador, int idEvento, int qntdIng, DateTime data)
        {
            var inserirVenda = _vendaDomainService.GerarVenda(idComprador, idEvento, qntdIng, data);
            return inserirVenda;

        }
    }
}