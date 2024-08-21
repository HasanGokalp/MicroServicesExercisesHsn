using Microsoft.EntityFrameworkCore;

namespace PaymentSys.Order.Context
{
    public class PaymentSysOrderCtx : DbContext
    {
        public PaymentSysOrderCtx(DbContextOptions<PaymentSysOrderCtx> options) : base(options)
        {

        }

        public PaymentSysOrderCtx()
        {

        }

        public DbSet<Models.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Models.Order>().Property(o => o.Name).IsRequired();
            modelBuilder.Entity<Models.Order>().OwnsOne(o => o.Address);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PaymentSysOrderDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
