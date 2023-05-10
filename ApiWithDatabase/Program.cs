using System.Reflection;
using System.Text.Json.Serialization;
using ApiWithDatabase;
using ApiWithDatabase.Models;
using ApiWithDatabase.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var path = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, path));
});
builder.Services.AddDbContext<UniversityDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDB"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddScoped<IGenericRepository<Student>,GenericRepository<Student>>();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();