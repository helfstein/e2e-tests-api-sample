using Microsoft.EntityFrameworkCore;
using PocApiSample;
using PocApiSample.Domain;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(opt => opt.UseInMemoryDatabase("ApiDbTest"));
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

var context = app.Services.CreateScope().ServiceProvider.GetService<MyDbContext>();
var pedidosIniciais = new List<Pedido>
{
    new Pedido {
        Id = Guid.Parse("b762abe4-1731-4c45-bfdf-36fbd73462ed"),
        CreatedAt = DateTime.Parse("21/02/2022 18:40", CultureInfo.GetCultureInfo("pt-BR")),
        Total = 1233.55M
    },
    new Pedido {
        Id = Guid.Parse("bc49fcae-a4ed-4e3e-9b9b-9c9d4226b152"),
        CreatedAt = DateTime.Parse("19/02/2022 11:54", CultureInfo.GetCultureInfo("pt-BR")),
        Total = 92.23M
    }
};
context?.Pedidos?.AddRange(pedidosIniciais);
context?.SaveChanges();


app.Run();
