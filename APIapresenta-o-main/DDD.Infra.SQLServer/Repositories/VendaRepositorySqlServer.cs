using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class VendaRepositorySqlServer : IVendaRepository
    {
        private readonly SqlContext _context;

        public VendaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteVenda(Venda venda)
        {
            try
            {
                _context.Set<Venda>().Remove(venda);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Venda GetVendaById(int id)
        {
            return _context.Vendas.Find(id);
        }

        public List<Venda> GetVendas()
        {
            return _context.Vendas.ToList();
        }

        public void InsertVenda(Venda venda)
        {
            _context.Add(venda);
            _context.SaveChanges();
        }

        public void UpdateVenda(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
