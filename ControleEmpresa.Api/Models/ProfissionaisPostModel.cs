using System.ComponentModel.DataAnnotations;

namespace ControleEmpresa.Api.Models
{
    public class ProfissionaisPostModel
    {
        
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,150}$", ErrorMessage = "O nome precisa ter entre 6 e 150 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do profissional.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o email.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe um CPF válido.")]
        [Required(ErrorMessage = "Informe o CPF.")]
        public string Cpf { get; set; }

        [RegularExpression("^[0-9]{8,12}$", ErrorMessage = "Informe um número de telefone com DDD e sem espaços.")]
        [Required(ErrorMessage = "Informe o telefone.")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
