using DDDExample.Application;
using DDDExample.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// JWT do�rulama ayarlar�n� ekleyelim.
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(opt=> {

    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // HTTPS gereklili�ini devre d��� b�rakabilirsiniz (development i�in).
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidIssuer = jwtSettings["Issuer"],
            ValidateAudience = false,
            ValidAudience = jwtSettings["Audience"],
            // Opsiyonel olarak, Token'�n ne kadar s�reyle ge�erli olaca��n� belirleyebilirsiniz:
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Bu �rnekte token s�resinin tam olarak ge�erli olmas� beklenir.
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

app.UseAuthentication(); // JWT do�rulama ekleyin.
app.UseAuthorization();

app.MapControllers();

app.Run();
