using DDD.Domain.GeralContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Venda
    {
        public int VendaId { get; set; }
        public Comprador Compradores { get; set; }

        public Eventos Eventos { get; set; }

        public DateTime Data { get; set; }

        public int QtdIngresso { get; set; }

    }
}
