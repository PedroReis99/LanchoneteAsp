﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    public class Bebida
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Combo> Combos { get; set; }
    }
}
