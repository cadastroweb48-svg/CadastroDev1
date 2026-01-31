using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public interface IUsuarioRepositorio
    {
		Task<Usuario?> BuscarPorEmailAsync(string email);
		Task AdicionarAsync(Usuario usuario);
	}
}
