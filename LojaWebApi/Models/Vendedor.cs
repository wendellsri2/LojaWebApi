using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LojaWebApi.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public double BaseSalarial { get; set; }
        public Departamento? Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVenda>? Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {
        }

        public Vendedor(int vendedorId, string? nome, string? email, DateTime dtNascimento, double baseSalarial, Departamento? departamento)
        {
            VendedorId = vendedorId;
            Nome = nome;
            Email = email;
            DtNascimento = dtNascimento;
            BaseSalarial = baseSalarial;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVenda rv )
        {
            Vendas?.Add(rv);
        }

        public void RemoveVendas(RegistroVenda rv)
        {
            Vendas?.Remove(rv);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.DataVenda >= inicial && rv.DataVenda <= final)
                    .Sum(rv => rv.Total);
        }
    }
}
