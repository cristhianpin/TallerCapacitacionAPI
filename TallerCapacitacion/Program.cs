using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TallerCapacitacion.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<TallerCapacitacionContext>(
   options =>
   {
       options.UseMySql(builder.Configuration.GetConnectionString("TallerCapacitacionDB"),
           Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
   });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
