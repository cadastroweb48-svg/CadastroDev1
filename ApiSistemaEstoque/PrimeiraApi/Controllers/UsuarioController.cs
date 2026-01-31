using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.DTOs.UsuarioDtos;
using PrimeiraApi.Service.UsuarioServic;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioValideitor _serviceCadastro;
		private readonly UsuarioLoginValideitor _servicLogin;

		public UsuarioController(UsuarioValideitor service , UsuarioLoginValideitor usuarioLoginValideitor)
        {
			_serviceCadastro = service;
			_servicLogin = usuarioLoginValideitor;
		}

        // 🔹 CADASTRO
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastar([FromBody] UsuarioCreatDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _serviceCadastro.CadastarAnsync(dto);
                return Created("", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest( new {erro = ex.Message });
            }

        }

        // 🔹 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDtos dto)
        {
            if (!ModelState.IsValid) 
              return BadRequest(ModelState);

            var sucesso = await _servicLogin.ValidarLoginAsync(dto.Email, dto.Senha);

            if (!sucesso)
                return Unauthorized("Email ou senha invalida");


			return Ok(new { mensagem = "Login realizado com sucesso" });

		}
	}
}
