using Microsoft.EntityFrameworkCore;

namespace PaymentFinalAPI.Models
{

    public class PaymentDetailsContext : DbContext
    {
        // DbContextOptions -> database provider (sql server, mysql itd) and database connection string
        public PaymentDetailsContext(DbContextOptions<PaymentDetailsContext> options) : base(options)
        {

        }

        public DbSet<PaymentDetailsModel> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Metoda szuka plików konfiguracyjnych
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}