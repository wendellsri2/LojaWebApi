using LojaWebApi.Data;
using LojaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaWebApi.Services
{
    public class DepartamentoService
    {
        private readonly LojaWebApiContext _context;

        public DepartamentoService(LojaWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ListarAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
