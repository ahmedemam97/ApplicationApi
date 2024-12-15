using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class UserConfig : IEntityTypeConfiguration<ApplicationUser>
    {

        //PasswordHasher<ApplicationBuilder> Hash = new();

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    //PasswordHash = Hash.HashPassword(null,"Admin"),
                    Email = "Admin@yahoo.com",
                    RoleId = 1,
                    RoleName = "Admin",
                    NormalizedEmail= "ADMIN@YAHOO.COM",
                    Password="Admin",
                    Name="Admin",
                    PhoneNumber = "01032882094",
                    EmailConfirmed=true,
                    LockoutEnabled=true,
                    TwoFactorEnabled=true,
                });          
        }
    }
}
