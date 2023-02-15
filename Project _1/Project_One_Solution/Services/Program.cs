using Business_Logic;
using Fluent_API;
using Fluent_API.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().WriteTo.File(@"E:\GitRepo\p1-bhargav-bhat\Project _1\Project_One_Solution\Services\Logs\logfile.txt", rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true).CreateLogger();

// Connection string configaration
Log.Information("----------Trying to connect with database-------------");
var config = builder.Configuration.GetConnectionString("TrainersDatabase");
builder.Services.AddDbContext<TrainerDatabaseProjectContext>(options => options.UseSqlServer(config));


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

// Trainer table operations configuration
builder.Services.AddScoped<ITrainerRepo, EFTrainerRepo>();
builder.Services.AddScoped<ITrainerLogic,TrainerLogic>();
//Skill table operations configurations
builder.Services.AddScoped<ISkillsRepo,EFSkillsRepo>();
builder.Services.AddScoped<ISkills,SkillsLogic>();
//Education table operations configuration
builder.Services.AddScoped<IEducateRepo,EFEducational>();
builder.Services.AddScoped<IEducationLogic,EducationLogic>();
//Work Experience table details configurations
builder.Services.AddScoped<IWorkRepo, EFWorkExpRepo>();
builder.Services.AddScoped<IWork, WorkExperienceLogic>();
// Additional details configurations
builder.Services.AddScoped<IAdditionalsRepo, EFAdditional>();
builder.Services.AddScoped<IAddLogic, AdditionalLogic>();

Log.Information("---------- Application Building --------------");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();
Log.Information("---------- Application Running -------------");
app.Run();

