using LojaWebApi.Data;
using LojaWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace LojaWebApi.Services
{
    public class RegistroVendaService
    {
        private readonly LojaWebApiContext _context;

        public RegistroVendaService(LojaWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVenda>> ProcurarDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroVenda select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataVenda >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataVenda <= maxDate.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataVenda)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVenda>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroVenda select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataVenda >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataVenda <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataVenda)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}