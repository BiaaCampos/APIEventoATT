using DDD.Domain.GeralContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IVendaRepository
    {
        public List<Venda> GetVendas();
        public Venda GetVendaById(int id);
        public void InsertVenda(Venda venda);
        public void UpdateVenda(Venda venda);
        public void DeleteVenda(Venda venda);
    }
}
