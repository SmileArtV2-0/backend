using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using SmileArtLab.API.Middleware;
using SmileArtLab.Auth.Application.Interfaces;
using SmileArtLab.Auth.Application.Services;
using SmileArtLab.Auth.Domain.Interfaces;
using SmileArtLab.Auth.Infrastructure.Repository;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmileArtLab API", Version = "v1" });

    // Configuración de seguridad para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token JWT con el prefijo 'Bearer '",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
       {
           {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   }
               },
               new string[] {}
           }
       });
});


//Conexion
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddScoped<IDbConnection>((sp) => new MySqlConnection(connString));
builder.Services.AddScoped<IDbConnection>((conn) => new SqlConnection(connString));

builder.Services.AddScoped<ITenantService, TenantService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();
builder.Services.AddScoped<ITrabajoRepository, TrabajoRepository>();
builder.Services.AddScoped<ITipoTrabajoRepository, TipoTrabajoRepository>();
builder.Services.AddScoped<IClinicaDoctorRepository, ClinicaDoctorRepository>();
builder.Services.AddScoped<IOrdenLaboratorioRepository, OrdenLaboratorioRepository>();
builder.Services.AddScoped<IOrdenTrabajoRespository, OrdenTrabajoRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IClinicaService, ClinicaService>();
builder.Services.AddScoped<ITrabajoService, TrabajoService>();
builder.Services.AddScoped<ITipoTrabajoService, TipoTrabajoService>();
builder.Services.AddScoped<IClinicaDoctorService, ClinicaDoctorService>();
builder.Services.AddScoped<IOrdenLaboratorioService, OrdenLaboratorioService>();
builder.Services.AddScoped<IOrdenTrabajoService, OrdenTrabajoService>();
//habilitar cors 
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()
       .WithExposedHeaders("X-TenantId"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<TenantMiddleware>();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
