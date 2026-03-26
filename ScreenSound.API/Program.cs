using SS.Banco;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScreenSound.API.EndPoints;
using ScreenSound.Models;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScreenSoundContext>(options =>
options.UseSqlServer("Server=localhost;Database=ScreenSoundDB;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();


app.UseSwagger();
app.UseSwaggerUI();

//Esse bloco serve pra rodar a seed quando a API inicia, usando o DbContext do sistema.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ScreenSoundContext>();
    await SD.SeedDatabaseAsync(context);
}


app.Run();
