using Microsoft.EntityFrameworkCore;
using CentralTicket.Contexts.Auth.Data;
using CentralTicket.Contexts.Profile.Data;
using CentralTicket.Contexts.Billing.Data;

namespace CentralTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var conn = builder.Configuration.GetConnectionString("Default");
            var serverVersion = ServerVersion.AutoDetect(conn);

            builder.Services.AddDbContext<AuthDbContext>(opt =>
                opt.UseMySql(conn, serverVersion));

            builder.Services.AddDbContext<ProfileDbContext>(opt =>
                opt.UseMySql(conn, serverVersion));

            builder.Services.AddDbContext<BillingDbContext>(opt =>
                opt.UseMySql(conn, serverVersion));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}