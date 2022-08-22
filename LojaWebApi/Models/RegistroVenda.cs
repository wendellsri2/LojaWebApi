using LojaWebApi.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace LojaWebApi.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]

        public double Total { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor? Vendedor { get; set; }
        public int VendedorId { get; set; }

        public RegistroVenda()
        {
        }

        public RegistroVenda(int vendaId, DateTime dataVenda, double total, StatusVenda status, Vendedor? vendedor)
        {
            Id = vendaId;
            DataVenda = dataVenda;
            Total = total;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
