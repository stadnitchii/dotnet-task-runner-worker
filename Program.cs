using Microsoft.EntityFrameworkCore;
using task_runner_api;
using task_runner_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<LongRunningTaskFactory>();

builder.Services.AddDbContext<MyContext>(options =>
{
	options.UseSqlServer("Server=localhost;Initial Catalog=test;TrustServerCertificate=True;Integrated Security =True;");
	options.EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
