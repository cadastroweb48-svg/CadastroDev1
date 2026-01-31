using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.DTOs.UsuarioDtos
{
    public class UsuarioLoginDtos
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }


    }
}
