using System;
using System.Collections.Generic;
using System.Text;
using AccountingSystem.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Infrastructure.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Balance>().HasData(
                new Balance
                {
                    AccountPyable = 0,
                    AccountRecevable = 0,
                    Building = 0,
                    Capital = 0,
                    Cash = 0,
                    Date = DateTime.Now,
                    Equipments = 0,
                    Goods = 0,
                    Land = 0,
                    Loans = 0,
                    SalaryPyable = 0,
                    Id = 1
                });

        }

    }
}
