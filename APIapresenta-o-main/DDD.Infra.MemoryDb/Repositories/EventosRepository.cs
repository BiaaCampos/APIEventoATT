using DDD.Domain.GeralContext;
using DDD.Infra.MemoryDb.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class EventosRepository : IEventosRepository
    {

        private readonly ApiContext _context;

        public EventosRepository(ApiContext context)
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

        public List<Eventos> GetEventos()
        {
            using (var context = new ApiContext())
            {
                var list = context.Eventos.ToList();
                return list;
            }
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
