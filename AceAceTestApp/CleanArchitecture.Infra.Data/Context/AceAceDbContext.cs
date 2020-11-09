using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Context
{
    public class AceAceDbContext : IdentityDbContext
    {
        public AceAceDbContext(DbContextOptions<AceAceDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' & 'DataEntry' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "A6F50C5D-C649-4B16-B236-3D3F10777F39", Name = "Administrator", NormalizedName = "Administrator".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "92FF8BC9-ACA8-4550-9504-20345850F5A0", Name = "DataEntry", NormalizedName = "DataEntry".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser();

            //Seeding the Admin User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "6B28D9BC-DBE6-4173-BA71-A3B72939E419", // primary key
                    UserName = "admin@test.com",
                    NormalizedUserName = "admin@test.com".ToUpper(),
                    Email = "admin@test.com",
                    NormalizedEmail = "admin@test.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(user, "P@ssw0rd"),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
            //Seeding the Data Entry User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "0E918062-8377-45C7-8DC0-91CD0F83AC89", // primary key
                    UserName = "dataentry@test.com",
                    NormalizedUserName = "dataentry@test.com".ToUpper(),
                    Email = "dataentry@test.com",
                    NormalizedEmail = "dataentry@test.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(user, "P@ssw0rd"),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "A6F50C5D-C649-4B16-B236-3D3F10777F39",
                    UserId = "6B28D9BC-DBE6-4173-BA71-A3B72939E419"
                }
            );
            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "92FF8BC9-ACA8-4550-9504-20345850F5A0",
                    UserId = "0E918062-8377-45C7-8DC0-91CD0F83AC89"
                }
            );


        }

    }
}
