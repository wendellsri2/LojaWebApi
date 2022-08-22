using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaWebApi.Models;

namespace LojaWebApi.Data
{
    public class LojaWebApiContext : DbContext
    {
        public LojaWebApiContext (DbContextOptions<LojaWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
        public DbSet<RegistroVenda> RegistroVenda { get; set; } = default!;        

    }
}
