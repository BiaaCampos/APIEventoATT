using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int RA { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }


    }
}
