using CleanArch.Application.Interfaces;
using CleanArch.Application.Sevices;
using Microsoft.Extensions.DependencyInjection;
using CleanArch.Infra.Data.Repository;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService( IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<ICourseService, CourseService>();

            //Data.Infra Layer
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
