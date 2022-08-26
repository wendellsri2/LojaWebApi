using LojaWebApi.Data;
using LojaWebApi.Models;

namespace LojaWebApi.Services
{
    public class DepartamentoService
    {
        private readonly LojaWebApiContext _context;

        public DepartamentoService(LojaWebApiContext context)
        {
            _context = context;
        }

        public List<Departamento> ListarAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
