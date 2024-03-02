using Microsoft.EntityFrameworkCore;
using STBRV.Bussiness.Service;
using STBRV.Entities;
using STBRV.Entities.DataContext;
using STBRV.Entities.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StbrvContext>(opc =>
{
    opc.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<Articulo>, ArticuloRepository>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();

builder.Services.AddScoped<IGenericRepository<ArticuloTiendum>, ArticuloTiendaRepository>();
builder.Services.AddScoped<IArticuloTiendaService, ArticuloTiendaService>();

builder.Services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IGenericRepository<ClienteArticulo>, ClienteArticuloRepository>();
builder.Services.AddScoped<IClienteArticuloService, ClienteArticuloService>();

builder.Services.AddScoped<IGenericRepository<Tiendum>, TiendaRepository>();
builder.Services.AddScoped<ITiendaService, TiendaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
