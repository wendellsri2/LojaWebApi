using LojaWebApi.Data;
using LojaWebApi.Models;
using LojaWebApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LojaWebApi.Services
{
    public class VendedorService
    {
        private readonly LojaWebApiContext _context;

        public VendedorService(LojaWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> ListarAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }
        public async  Task InserirAsync(Vendedor obj)
        {            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Vendedor> ProcurarAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.VendedorId == id);
        }

        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = _context.Vendedor.Find(id);
                _ = _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Esse vendedor não pode ser deletado tem pedido no nome!");
            }
        }

        public async Task AtualizarAsync(Vendedor obj)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.VendedorId == obj.VendedorId);
            if (!hasAny)
            {
                throw new NotFoundException("Vendedor não encontrado");
            }
            try 
            { 
            _context.Update(obj);
            await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
