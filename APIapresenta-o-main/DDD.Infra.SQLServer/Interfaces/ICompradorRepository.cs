using DDD.Domain.GeralContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ICompradorRepository
    {
        public List<Comprador> GetComprador();
        public Comprador GetCompradorById(int id);
        public void InsertComprador(Comprador comprador);
        public void UpdateComprador(Comprador comprador);
        public void DeleteComprador(Comprador comprador);
    }
}
