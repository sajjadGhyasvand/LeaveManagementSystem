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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
            {
                Id = "8f096a00-53d6-495c-9aaa-5d2452e0ab00",
                Name="Employe",
                NormalizedName="EMPLOYEE"
            }, new IdentityRole
            {
                Id = "8f096a20-53c6-495c-9aaa-5d2452e0ab00",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }

            );
        }
    }
}
