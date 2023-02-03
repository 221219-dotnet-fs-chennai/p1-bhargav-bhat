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

// Connection string configaration
var config = builder.Configuration.GetConnectionString("TrainersDatabase");
builder.Services.AddDbContext<TrainerDatabaseProjectContext>(options => options.UseSqlServer(config));

// Trainer table operations configuration
builder.Services.AddScoped<ITrainerRepo, EFTrainerRepo>();
builder.Services.AddScoped<ITrainerLogic,TrainerLogic>();
//Skill table operations configurations
builder.Services.AddScoped<ISkillsRepo,EFSkillsRepo>();
builder.Services.AddScoped<ISkills,SkillsLogic>();
//Education table operations configuration
builder.Services.AddScoped<IEducateRepo,EFEducational>();
builder.Services.AddScoped<IEducationLogic,EducationLogic>();

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
