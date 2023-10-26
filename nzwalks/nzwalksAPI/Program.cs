using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nzwalks.API.Data;
using nzwalks.API.Mappings;
using nzwalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<nzwalksdbcontext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("nzwalksconnectionstring"))
);

//Adding repository
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

//Adding/injecting  automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
