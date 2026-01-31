
using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.DTOs.UsuarioDtos
{
    public class UsuarioCreatDto
    {

		[Required(ErrorMessage ="O Nome é obrigatorio")]
		[MinLength(4 , ErrorMessage ="O nome deve ter no Minimo 4 caracteres")]
        public string Nome { get; set; }

		[Required(ErrorMessage = "O e-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "A senha é obrigatória")]
		[MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
		public string Senha { get; set; }

	}
}
