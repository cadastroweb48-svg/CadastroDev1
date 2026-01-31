using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Service.UsuarioServic;
using PrimeiraApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFront",
		policy =>
		{
			policy
				.WithOrigins("http://127.0.0.1:5501", "http://localhost:5501")
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});

// 🔹 Banco de dados
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseMySql(
		connectionString,
		ServerVersion.AutoDetect(connectionString)
	);
});

builder.Services.AddScoped<UsuarioValideitor>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<UsuarioLoginValideitor>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// 🔹 ORDEM IMPORTA
app.UseCors("AllowFront");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
