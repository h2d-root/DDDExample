using DDDExample.Application;
using DDDExample.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
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
};
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});
builder.Services.AddSwaggerGen();

// JWT doðrulama ayarlarýný ekleyelim.
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(opt=> {

    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // HTTPS gerekliliðini devre dýþý býrakabilirsiniz (development için).
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidIssuer = jwtSettings["Issuer"],
            ValidateAudience = false,
            ValidAudience = jwtSettings["Audience"],
            // Opsiyonel olarak, Token'ýn ne kadar süreyle geçerli olacaðýný belirleyebilirsiniz:
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Bu örnekte token süresinin tam olarak geçerli olmasý beklenir.
        };
    });

builder.Services.AddHttpContextAccessor();

builder.Services.ApplicationRegistration();
builder.Services.InfrastructureRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // JWT doðrulama ekleyin.
app.UseAuthorization();

app.MapControllers();

app.Run();
