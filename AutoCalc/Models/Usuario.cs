
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCalc.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessário Inserir CPF")]
        [Display(Name = "Número do CPF")]
        public string? DocumentoCPF { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Nome")]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Sobre Nome")]
        [MaxLength(100)]
        [Display(Name = "Sobrenome")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Endereço de Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Necessário Inserir Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }

    }
}
