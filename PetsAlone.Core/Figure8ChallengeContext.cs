using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace PetsAlone.Core
{
    /// <summary>
    /// This implementation is acceptable for the time being, let's focus on the
    /// other features that will help us get something live ASAP
    /// </summary>
    public class Figure8ChallengeContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<My_Pet_Class> Pets { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }

        private PasswordHasher<ApplicationUser> _passwordHasher { get; set; }

        public Figure8ChallengeContext(
            DbContextOptions<Figure8ChallengeContext> options) : base(options)
        {
            _passwordHasher = new PasswordHasher<ApplicationUser>();
            Database.EnsureCreated();
        }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");

            modelBuilder.Entity<My_Pet_Class>().HasData(new My_Pet_Class
            {
                Id = 1,
                Name = "Max",
                PetType = 2,
                MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(6))
            });

            modelBuilder.Entity<My_Pet_Class>().HasData(new My_Pet_Class
            {
                Id = 2,
                Name = "Fluffy",
                PetType = 1,
                MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(10))
            });

            modelBuilder.Entity<My_Pet_Class>().HasData(new My_Pet_Class
            {
                Id = 3,
                Name = "Snowball",
                PetType = 4,
                MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(2))
            });

            modelBuilder.Entity<ContactDetails>().HasData(new ContactDetails
            {
                Id = 1,
                Name = "Olawale Ogunleye",
                PhoneNumber = "+234 7060 578 240",
                DateCreated = DateTime.Now,
                UpdatedAt = null

            });
            modelBuilder.Entity<ContactDetails>().HasData(new ContactDetails
            {
                Id = 2,
                Name = "John Mx",
                PhoneNumber = "+44 7060 578 240",
                DateCreated = DateTime.Now,
                UpdatedAt = null

            });

            SeedApplicationUsers(modelBuilder);
        }

        private void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            var username = "elmyraduff";
            var email = "elmyraduff@petsalone.com";
            var password = "MontanaMax!!";

            var user = new ApplicationUser
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }
    }
}