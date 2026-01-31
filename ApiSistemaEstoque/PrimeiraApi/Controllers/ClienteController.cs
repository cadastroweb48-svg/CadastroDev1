using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Models;
using PrimeiraApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeiraApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ClienteController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
		{
			return await _context.Cliente.ToListAsync();
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Cliente>> GetById(int id)
		{
			var cliente = await _context.Cliente.FindAsync(id);

			if (cliente == null)
				return NotFound();

			return cliente;
		}

		[HttpPost]
		public async Task<ActionResult> Post(Cliente cliente)
		{
			_context.Cliente.Add(cliente);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Cliente cliente)
		{
			if (id != cliente.Id)
				return BadRequest();

			_context.Entry(cliente).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var cliente = await _context.Cliente.FindAsync(id);

			if (cliente == null)
				return NotFound();

			_context.Cliente.Remove(cliente);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
