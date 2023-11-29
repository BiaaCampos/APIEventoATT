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
    public class EventosRepositorySqlServer : IEventosRepository
    {

        private readonly SqlContext _context;

        public EventosRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteEventos(Eventos eventos)
        {
            try
            {
                _context.Set<Eventos>().Remove(eventos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Eventos GetEventosById(int id)
        {
            return _context.Eventos.Find(id);
        }

        public List<Eventos> GetPorNome(string nome)
        {

            return _context.Eventos.Where(x => x.NomeEvento.ToUpper().Contains(nome.ToUpper())).ToList();
        }

        public List<Eventos> GetEventos()
        {
            //return  _context.Eventoss.Include(x => x.Disciplinas).ToList();
            return _context.Eventos.ToList();

        }

        public void InsertEventos(Eventos eventos)
        {
            try
            {
                _context.Eventos.Add(eventos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateEventos(Eventos eventos)
        {
            try
            {
                _context.Entry(eventos).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
