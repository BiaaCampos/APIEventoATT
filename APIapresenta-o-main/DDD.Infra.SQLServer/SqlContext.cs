using DDD.Domain.GeralContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventosDb");
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                .HasMany(e => e.VendaId)
                .HasRequired(e => e.Id)
                .UsingEntity<Venda>();


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            //modelBuilder.Entity<Eventos>().ToTable("Eventos");
            ////https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }*/
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}
