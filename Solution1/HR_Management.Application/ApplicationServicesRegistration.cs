﻿using HR_Management.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
           /* services.AddAutoMapper(typeof(MappingProfile));*/
           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
