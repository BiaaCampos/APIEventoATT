using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Eventos
    {
        [Key]
        public int EventosId { get; set; }
        public string NomeEvento { get; set; }

        public string Descricao { get; set; }

        public float ValorIngresso { get; set; }

        public string LocalEvento { get; set; }

        public DateTime DataEvento { get; set; }

        public int IngressosDisponiveis { get; set; }

        [DefaultValue(true)]
        public bool Ativo { get; set; }



    }
}
