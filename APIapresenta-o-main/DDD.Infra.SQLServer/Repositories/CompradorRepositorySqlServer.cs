using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infra.SQLServer.Repositories
{
    public class CompradorRepositorySqlServer : ICompradorRepository
    {
        private readonly SqlContext _context;

        public CompradorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteComprador(Comprador comprador)
        {
            try
            {
                _context.Set<Comprador>().Remove(comprador);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log or handle specific database-related exceptions
                throw new Exception("Error deleting Comprador. See inner exception for details.", ex);
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                throw new Exception("An error occurred while deleting Comprador.", ex);
            }
        }

        public Comprador GetCompradorById(int id)
        {
            try
            {
                return _context.Compradores.Find(id);
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                throw new Exception("An error occurred while retrieving Comprador by ID.", ex);
            }
        }

        public List<Comprador> GetComprador()
        {
            try
            {
                return _context.Compradores.ToList();
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                throw new Exception("An error occurred while retrieving Compradores.", ex);
            }
        }

        public void InsertComprador(Comprador comprador)
        {
            try
            {
                _context.Compradores.Add(comprador);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log or handle specific database-related exceptions
                throw new Exception("Error inserting Comprador. See inner exception for details.", ex);
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                throw new Exception("An error occurred while inserting Comprador.", ex);
            }
        }

        public void UpdateComprador(Comprador comprador)
        {
            try
            {
                _context.Entry(comprador).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log or handle concurrency-related exceptions
                throw new Exception("Error updating Comprador. Concurrency conflict. See inner exception for details.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Log or handle specific database-related exceptions
                throw new Exception("Error updating Comprador. See inner exception for details.", ex);
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                throw new Exception("An error occurred while updating Comprador.", ex);
            }
        }
    }
}
