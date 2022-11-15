using System.ComponentModel.DataAnnotations;

namespace ControleEmpresa.Api.Models
{
    public class ProfissionaisPutModel
    {
        [Required(ErrorMessage = "Informe o ID do profissional")]
        public Guid IdProfissional { get; set; }

        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,150}$", ErrorMessage = "Informe um nome válido de 6 a 150 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do profissional.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o email.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe um CPF válido.")]
        [Required(ErrorMessage = "Informe o CPF.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o telefone.")]
        public string Telefone { get; set; }

    }
}
