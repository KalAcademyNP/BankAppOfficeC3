using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BankDb;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Account>().HasKey(a => a.AccountNumber);
            modelBuilder.Entity<Account>(e =>
            {
                e.Property(a => a.AccountNumber)
                .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(a => a.AccountName)
                    .IsRequired()
                    .HasMaxLength(250);

                e.Property(a => a.AccountType)
                    .IsRequired();

            });

            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);
            modelBuilder.Entity<Transaction>(e =>
            {
                e.Property(t => t.TransactionId).ValueGeneratedOnAdd();
                e.Property(t => t.TransactionDate).IsRequired();
                e.Property(t => t.Amount).IsRequired();
                e.Property(t => t.AccountNumber).IsRequired();

                e.HasOne(t => t.Account)
                    .WithMany()
                    .HasForeignKey(t => t.AccountNumber);
            });

                
        }
    }
}
