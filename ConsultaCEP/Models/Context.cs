using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.Models
{
    public class Context : DbContext
    {
        public DbSet<Cep> Ceps { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
