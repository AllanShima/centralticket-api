using CentralTicket.Contexts.Auth;
using CentralTicket.Contexts.Auth.Interfaces.IRepositories;
using CentralTicket.Contexts.Auth.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

namespace CentralTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<TokenGenerator>();

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<Contexts.Auth.Data.Context>(options =>
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<Contexts.Auth.UseCases.RegisterUseCase>();
            builder.Services.AddScoped<Contexts.Auth.UseCases.LoginUseCase>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["AppSettings:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
                        ValidateIssuerSigningKey = true

                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
