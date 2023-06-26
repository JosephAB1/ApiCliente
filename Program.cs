using ApiCliente.DbContexts;
using ApiCliente.Mapper;
using ApiCliente.Repository;
using ApiCliente.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var cn = builder.Configuration.GetConnectionString("CN");

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteServices>();
builder.Services.AddScoped<IFlotaRepository, FlotaServices>();
builder.Services.AddScoped<IMarcaRepository, MarcaServices>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cn));




var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new ClienteMapper());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);


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

app.UseCors("FrontEnd");

app.Run();
