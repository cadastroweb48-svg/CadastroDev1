
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.Repositories;

namespace MinhaApi.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly AppDbContext _context;

		public ClienteRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Cliente>> GetAllAsync()
		{
			return await _context.Cliente.ToListAsync();
		}

		public async Task<Cliente?> GetByIdAsync(int id)
		{
			return await _context.Cliente.FindAsync(id);
		}

		public async Task AddAsync(Cliente cliente)
		{
			_context.Cliente.Add(cliente);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Cliente cliente)
		{
			_context.Cliente.Update(cliente);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var cliente = await GetByIdAsync(id);
			if (cliente != null)
			{
				_context.Cliente.Remove(cliente);
				await _context.SaveChangesAsync();
			}
		}
	}
}
