using System.Collections.Generic;
using System.Linq;

namespace LojaWebApi.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string? Nome { get; set; }
        public ICollection<Vendedor>? Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int departamentoId, string? nome)
        {
            DepartamentoId = departamentoId;
            Nome = nome;
        }
        
        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores?.Add(vendedor);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicial, final));
        }
    }
}
