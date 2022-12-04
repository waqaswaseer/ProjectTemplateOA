using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Data;
using Project.Domain.Models;
using Project.Repositary.IRepositary;
using Project.Repositary.Repositary;
using Project.Services.CustomServices;
using Project.Services.ICustomServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Sql Dependency Injection
var ConnectionString =
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Product>, ProductService>();
/*builder.Services.AddScoped<ICustomService<Resultss>, ResultService>();
builder.Services.AddScoped<ICustomService<Departments>, DepartmentsService>();
builder.Services.AddScoped<ICustomService<SubjectGpas>, SubjectGpasService>();*/
#endregion

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
