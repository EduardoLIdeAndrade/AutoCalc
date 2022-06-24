using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCalc.Models
{
    [Table("Abastecimentos")]
    public class Abastecimento
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Data")]
        [DataType(DataType.Date)]
        public string? Data { get; set; }

        [Display(Name = "Nome do Posto")]
        public string? NomeDoPosto { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Valor Por Litro")]
        [Display(Name = "Valor Por Litro")]
        public string? ValorPorLitro { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Valor Total(R$)")]
        [Display(Name = "Valor Total em (R$)")]
        public string? ValorTotal { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Total de Litros Abastecido")]
        [Display(Name = "Total de Litros Abastecido")]
        public string? TotaldeLitrosAbastecido { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Kilometragem Total")]
        [Display(Name = "Kilometragem Total")]
        public string? KilometragemTotal { get; set; }

        [Required]
        [Display(Name = "Alcool ou Gasolina")]
        public string? TipoDeCombustivel { get; set; }

        public string? Observações { get; set; }

        public string? Usuario { get; set; }
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo? Veiculo { get; set; }
        
    }
}
