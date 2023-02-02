using Business_Logic;
using Fluent_API;
using Fluent_API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var config = builder.Configuration.GetConnectionString("Trainers_Database");

builder.Services.AddDbContext<TrainerDatabaseProjectContext>(options => options.UseSqlServer(config));

//We are creating the instance of EFRepo by Dependency Inverison
//builder.Services.AddScoped<IRepo<DataFluentApi.Entities.Restaurant>, EFRepo>();
builder.Services.AddScoped<ITrainerRepo<Fluent_API.Entities.Trainer>, Fluent_API.EFRepo>();

//We are creating the instance of Logic by Dependency Inverison
builder.Services.AddScoped<ILogic,Logic>();

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
