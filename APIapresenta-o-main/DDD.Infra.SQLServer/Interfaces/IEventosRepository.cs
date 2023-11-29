using DDD.Domain.GeralContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEventosRepository
    {
        public List<Eventos> GetEventos();
        public Eventos GetEventosById(int id);
        public List<Eventos> GetPorNome(string nome);
        public void InsertEventos(Eventos eventos);
        public void UpdateEventos(Eventos eventos);
        public void SoftDeleteEventos(int idEvento);
    }
}
