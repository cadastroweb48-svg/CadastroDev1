
using PrimeiraApi.Data;
using PrimeiraApi.DTOs.UsuarioDtos;
using PrimeiraApi.Models;



namespace PrimeiraApi.Service.UsuarioServic
{
    public class UsuarioValideitor
    {
        private readonly AppDbContext _context;
       // private readonly IUsuarioRepositorio 
        public UsuarioValideitor(AppDbContext context)
        {
            _context = context;

        }

        public async Task<UsuarioRepositorio> CadastarAnsync(UsuarioCreatDto dto)
        {
            var emailExitente = _context.Usuarios.Any(u => u.Email == dto.Email);

            if (emailExitente)

                throw new Exception("E-mail já cadastrado");


            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            };


            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioRepositorio
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };

        }
	}
}
