using LojaWebApi.Data;
using LojaWebApi.Models;

namespace LojaWebApi.Services
{
    public class VendedorService
    {
        private readonly LojaWebApiContext _context;

        public VendedorService(LojaWebApiContext context)
        {
            _context = context;
        }

        public List<Vendedor> Listar()
        {
            return _context.Vendedor.ToList();
        }
    }
}
