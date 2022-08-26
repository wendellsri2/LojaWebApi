using LojaWebApi.Data;
using LojaWebApi.Models;
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

        public List<Vendedor> Listar()
        {
            return _context.Vendedor.ToList();
        }
        public void Inserir(Vendedor obj)
        {            
            _context.Add(obj);
            _ = _context.SaveChanges();
        }
        public Vendedor Procurar(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.VendedorId == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _ = _context.Vendedor.Remove(obj);
            _ = _context.SaveChanges();
        }
    }
}
