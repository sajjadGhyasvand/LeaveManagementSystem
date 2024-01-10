using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using HR_Management.Identity.Models;
using HR_Management.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString"),
                    b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<LeaveManagementIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthService>();
            /*services.AddTransient<IUserService,UserService>();*/
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew   = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),
                };
            });

            return services;

        }
    }
}
