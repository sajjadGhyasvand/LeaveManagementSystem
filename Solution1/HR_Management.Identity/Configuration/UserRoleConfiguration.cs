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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "0557dadc-25ab-4b04-9cda-5312df924314",
                    RoleId = "8f096a20-53c6-495c-9aaa-5d2452e0ab00"
                },
                new IdentityUserRole<string>
                {
                    UserId = "7a4c063f-f91e-46c2-9e29-1563f4f0cead",
                    RoleId = "8f096a00-53d6-495c-9aaa-5d2452e0ab00"
                });
        }
    }
}
