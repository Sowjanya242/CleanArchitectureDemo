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
using CleanArch.Domain.Core.Bus;
using Microsoft.IdentityModel.Tokens;
using CleanArch.Infra.Bus;
using MediatR;
using CleanArch.Domain.Commands;
using CleanArch.Domain.CommandHandlers;
using CleanArch.Infra.Data.Context;

namespace ClassArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService( IServiceCollection services)
        {
            //Domain In memory bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handler
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            //Application Layer
            services.AddScoped<ICourseService, CourseService>();

            //Data.Infra Layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<UniversityDBContext>();
        }
    }
}
