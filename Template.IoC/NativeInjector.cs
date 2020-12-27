using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Aplication.Interfaces;
using Template.Aplication.Services;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Template.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
