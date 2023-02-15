using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase("EmployeeList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/employee/get", async (EmployeeContext ec) =>
await ec.Employees.ToListAsync());
app.MapPost("/employee/add", async (Employee emp, EmployeeContext ec) =>
{
    ec.Employees.Add(emp);
    await ec.SaveChangesAsync();
    return Results.Ok(emp);

});

app.MapPut("/employee/update", async (int id, Employee emp, EmployeeContext ec) =>
{
    var key = await ec.Employees.FindAsync(id);
    if (key is null) return Results.NotFound();
    key.Name= emp.Name;
    key.Role= emp.Role;
    await ec.SaveChangesAsync();
    return Results.Ok("Updated");

});

app.MapDelete("/employee/delete", async (int id, EmployeeContext ec) =>
{
    if (await ec.Employees.FindAsync(id) is Employee emp)
    {
        ec.Employees.Remove(emp);
        await ec.SaveChangesAsync();
        return Results.Ok(emp);
    }
    return Results.NotFound();
});

app.Run();

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}

class EmployeeContext:DbContext
{
    public EmployeeContext(DbContextOptions options):base(options)
    { 
    }
    public DbSet<Employee> Employees { get; set;}
}