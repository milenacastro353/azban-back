using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataAccess
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderState> OrderState { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Deparment> Deparments { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Client>().ToTable("Clientes")
                .Property("")
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");*/
        }
    }
}
