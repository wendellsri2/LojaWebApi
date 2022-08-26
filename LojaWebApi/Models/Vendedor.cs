using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LojaWebApi.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        public int VendedorId { get; set; }

        [Required(ErrorMessage ="{0} obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = 
            "Tamanho do campo {0} é entre {2} e {1} caracters")]
        public string? Nome { get; set; }
                
        [Required(ErrorMessage = "{0} obrigatório!")]
        [EmailAddress(ErrorMessage = "Digite um email Válido!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [Range(100.0, 50000.0, ErrorMessage= "{0} deve ser de {1} to {2}")]
        [Display(Name = "Base Salarial")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
