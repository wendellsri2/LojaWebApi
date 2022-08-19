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

        public DbSet<LojaWebApi.Models.Department> Department { get; set; } = default!;
    }
}
