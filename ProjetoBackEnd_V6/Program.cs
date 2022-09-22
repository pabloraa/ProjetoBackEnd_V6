
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.DataBaseConnection;
using Repositories.Interfaces;
using Repositories.Repository;
using Services.Interfaces;
using Services.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(@"Server = DESKTOP-10HCQPV\SQLEXPRESS; Database = Tarefas; Trusted_Connection = True;"));

builder.Services.AddScoped<IRespositoryTarefa, RepositoryTarefa>();
builder.Services.AddScoped<IValidator<Tarefa>, TarefaValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
