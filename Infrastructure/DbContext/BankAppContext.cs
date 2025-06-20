using ApplicationCore.Domain.Entities.Identity;
using Core.Domain.Entities;
using Entities.BanksEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankAppContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<BankEntity> Bank { get; set; }
        public DbSet<CardEntity> Card {  get; set; }
        public DbSet<UserEntity> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BankEntity>().ToTable("Banks");
            modelBuilder.Entity<CardEntity>().ToTable("Cards");
            modelBuilder.Entity<UserEntity>().ToTable("Persons");

            modelBuilder.Entity<CardEntity>()
                .HasOne(c=>c.Bank)
                .WithMany(b=>b.Cards)
                .HasForeignKey(c=>c.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u=>u.Bank)
                .WithMany(b=>b.Users)
                .HasForeignKey(u=>u.BankId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public BankAppContext(DbContextOptions<BankAppContext> options) : base(options)
        {

        }
    }
}
