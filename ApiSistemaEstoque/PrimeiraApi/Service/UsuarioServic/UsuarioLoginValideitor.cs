using PrimeiraApi.Repositories;

namespace PrimeiraApi.Service.UsuarioServic
{
    public class UsuarioLoginValideitor
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioLoginValideitor(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

		public async Task<bool> ValidarLoginAsync(string email, string senha)
		{
			var usuario = await _usuarioRepositorio.BuscarPorEmailAsync(email);

			if (usuario == null)
				return false;

			return BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);
		}

	}
}
