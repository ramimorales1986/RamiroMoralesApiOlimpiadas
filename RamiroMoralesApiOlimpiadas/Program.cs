using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio;
using RamiroMoralesApiOlimpiadas.Repositorio.Log;
using RamiroMoralesApiOlimpiadas.Repositorio.Resultados;
using RamiroMoralesApiOlimpiadas.Repositorio.Usuario;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("setting").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<INeResultado, NeResultado>();
builder.Services.AddScoped<IResultadoRepositorio, ResultadoRepositorio>();
builder.Services.AddScoped<INeLog, NeLog>();
builder.Services.AddScoped<ILogRepositorio, LogRepositorio>();
builder.Services.AddScoped<INeValidacion, NeValidacion>();
builder.Services.AddScoped<IValidacionRepositorio, ValidacionRepositorio>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
