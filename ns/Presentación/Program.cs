using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Acceso_a_Datos.Repositorios;
using Ecommerce.Negocio.Interfaces;
using Ecommerce.Negocio.Servicios;
using Ecommerce.Negocio.Validadores;
using Ecommerce.Presentación.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddOpenApi();
//REGISTRO DE LOS SERVICIOS
builder.Services.AddScoped<ICategoriaServicio,CategoriaServicio>(); // Aquí le decimos a ASP.NET qué clase debe implementar cuando se utilize la interfaz ICategoriaService
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ISubCategoriaServicio, SubCategoriaServicio>();

//REGISTRO DE LOS REPOSITORIOS
builder.Services.AddScoped<ISubCategoriaRepositorio, SubCategoriaRepositorio>();
builder.Services.AddScoped<IMarcaServicio, MarcaServicio>();
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IJwtService, JwtService>();

//REGISTRO DE LOS VALIDADORES
builder.Services.AddScoped<CategoriaValidador>();
builder.Services.AddScoped<SubCategoriaValidador>();
builder.Services.AddScoped<MarcaValidador>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = 
                  new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        // Limpiamos las rutas por defecto
        options.ViewLocationFormats.Clear();

        // Le indicamos que busque dentro de /Presentación/Views/
        options.ViewLocationFormats.Add("/Presentación/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Presentación/Views/Shared/{0}.cshtml");
    }).AddRazorRuntimeCompilation();
Log.Logger =
    new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval:
            RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

//Middlewares Implementadas
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LogginMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.Run();
