using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlanetumApplication.Dto;
using PlanetumApplication.Mappers;
using PlanetumApplication.Services;
using PlanetumApplication.Validator;
using PlanetumDomain.Interfaces;
using PlanetumInfrastructure.Data;
using PlanetumInfrastructure.Repositories;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
                

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("PlanetumConnection");
builder.Services.AddDbContext<PlanetumDbContext>(options => options.UseSqlServer(connectionString));

// Add Service
builder.Services.AddScoped<IInspectionService, InspectionService>();

// Add Repository
builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();

// Add JWT Authentication
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inspection.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
           "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
           "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
           "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
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
            Array.Empty<string>()
        }
    });
});
//Configuration of JWT Token
var key = Encoding.UTF8.GetBytes(builder.Configuration["Key:Secret"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Adding Auto Mapper Configuration
builder.Services.AddAutoMapper(typeof(ConfigurationMapping));

//Adding Fluent Validation
builder.Services.AddScoped<IValidator<InspectionDto>, InspectionsValidator>();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(InspectionsValidator));

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run();
