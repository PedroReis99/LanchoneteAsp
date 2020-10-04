using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    public class Acompanhamento
    {
        public int Id { get; set; }
        public string nome { get; set; }

        public List<Combo> Combos { get; set; }
    }
}
