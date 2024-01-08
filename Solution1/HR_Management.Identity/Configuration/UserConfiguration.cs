using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "0557dadc-25ab-4b04-9cda-5312df924314",
                    Email = "admin@admin.admin",
                    NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                    FirstName = "Admin",
                    LastName = "AdminZade",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null,"P@ssword1"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "7a4c063f-f91e-46c2-9e29-1563f4f0cead",
                    Email = "user@user.user",
                    NormalizedEmail = "USER@USER.USER",
                    FirstName = "system",
                    LastName = "user",
                    UserName = "userian",
                    NormalizedUserName = "USER",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
