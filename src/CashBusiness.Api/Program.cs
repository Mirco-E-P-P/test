using CashBusiness.Infraestructure;
using CashBusiness.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Server=DESKTOP-2TTGTQJ;Database=pruebabasedatos;Integrated Security=True; TrustServerCertificate=True",
    b => b.MigrationsAssembly("CashBusiness.Api")));






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
