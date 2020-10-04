using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    public class Context : DbContext
    {
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Acompanhamento> Acompanhamentos { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Combo> Combos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//Quando o metodo OnConfiguring é declardo aqui, só é preciso chama-lo no Startup.cs
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Lanchonete;Integrated Security=True");
        }
    }
}
