using DDD.Infra.SQLServer.Interfaces;
using DDD.Domain.GeralContext;
using Microsoft.Extensions.Logging;

namespace DDD.DomainService
{
    public class VendaDomainService
    {
        readonly IVendaRepository _vendaRepository;
        readonly ICompradorRepository _compradorRepository;
        readonly IEventosRepository _eventosRepository;

        public VendaDomainService(IVendaRepository vendaRepository, ICompradorRepository compradorRepository,
            IEventosRepository eventosRepository)
        {
            _vendaRepository = vendaRepository;
            _compradorRepository = compradorRepository;
            _eventosRepository = eventosRepository;
        }

        public Venda GerarVenda(int idComprador, int idEvento, int qntdIng)
        {
            try
            {
       
                var retComprador = _compradorRepository.GetCompradorById(idComprador);
                var retEvento = _eventosRepository.GetEventosById(idEvento);
                if ((retComprador == null ) || (retEvento == null))
                {
                    throw new Exception("Comprador ou o Evento não existem");
                }
                Venda insVenda = new Venda();
                insVenda.Compradores = retComprador;
                insVenda.Eventos = retEvento;
                DecIngresso(retEvento, qntdIng);
                insVenda.QtdIngresso = qntdIng;
                retEvento.IngressosDisponiveis = retEvento.IngressosDisponiveis - qntdIng;

                _vendaRepository.InsertVenda(insVenda);
                return insVenda;

            }
            catch (Exception ex )
            {
                throw ex;
            }
            
        }

        public void DecIngresso(Eventos eventoObj,int qntIng) 
        {
            eventoObj.IngressosDisponiveis = eventoObj.IngressosDisponiveis - qntIng;
            _eventosRepository.UpdateEventos(eventoObj);
            
            
        }
    }
}