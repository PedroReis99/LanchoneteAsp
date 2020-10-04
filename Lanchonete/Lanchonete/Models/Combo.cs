using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    public class Combo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int LancheId { get; set; }
        public Lanche Lanche { get; set; }
        public int AcompanhamentoId { get; set; }
        public Acompanhamento Acompanhamento { get; set; }
        public int BebidaId { get; set; }
        public Bebida Bebida { get; set; }
        public decimal Preco { get; set; }
    }
}
