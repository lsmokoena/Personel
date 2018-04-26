using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;
using Dapper;
using System.Data.SqlClient;


namespace DAL.Models
{
    public class PersonelContext : DbContext
    {
        public PersonelContext(DbContextOptions<PersonelContext> options) : base(options)
        {
        }

        public PersonelContext(string connectionString) : base(getOptions(connectionString))
        {
           
        }

        private static DbContextOptions<PersonelContext> getOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonelContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }
        
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Person> Person { get; set; }
        //public DbSet<PersonSkill> PersonSkill { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<MessageType> MessageType { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<NotificationContent> NotificationContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSkill>()
                .HasKey(up => new
                {
                    up.PersonId,
                    up.SkillId
                });

            modelBuilder.Entity<PersonSkill>()
                .HasOne(b => b.Person)
                .WithMany(a => a.PersonSkill)
                .HasForeignKey(up => up.PersonId);

            modelBuilder.Entity<PersonSkill>()
                .HasOne(a => a.Skill)
                .WithMany(b => b.PersonSkill)
                .HasForeignKey(up => up.SkillId);
        }

        internal void CreateAndMigrateDatabase()
        {
            //create the database if it does not exist and then apply all migrations
            this.Database.Migrate();
        }

        internal void ExecuteSqlStatement(string statement)
        {
            this.Database.ExecuteSqlCommand(statement);
        }
    }

    
}
