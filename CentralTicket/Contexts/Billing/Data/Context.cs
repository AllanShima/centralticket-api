using Microsoft.EntityFrameworkCore;
using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(sale => sale.Id);

            modelBuilder.Entity<Ticket>()
                .HasKey(ticket => ticket.Id);

            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<Event>()
                .HasKey(evnt => evnt.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
