  
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> BuscarPorEmailAsync(string email) {

			return await _context.Usuarios
									.FirstOrDefaultAsync(u => u.Email == email);

		}
		public async Task AdicionarAsync(Usuario usuario)
		{
			_context.Usuarios.Add(usuario);
			await _context.SaveChangesAsync();
		}



	}
}
