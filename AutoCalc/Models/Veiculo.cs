using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCalc.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessário Nome/Modelo do Veículo")]
        [MaxLength(100)]
        [Display(Name = "Modelo/Nome")]
        public string? ModeloDoVeiculo { get; set; }

        [Required(ErrorMessage = "Necessário Inserir a Placa do Veículo")]
        [MaxLength(7)]
        [Display(Name = "Placa")]
        public string? PlacaDoVeiculo { get; set; }

        [Required(ErrorMessage = "Necessário Inserir o Ano do Veículo")]
        [MaxLength(4)]
        [Display(Name = "Ano do Veículo")]
        public string? AnoDoVeiculo { get; set; }

        public string? Usuario { get; set; }

        public ICollection<Abastecimento>? Abastecimentos { get; set; }
    }
}
