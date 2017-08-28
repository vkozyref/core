using CoreApp.DataAccess.Persistance;
using CoreApp.DataAccess.Repository;
using CoreApp.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace CoreApp.DataAccess.IocConfiguration
{
    public static class DataAccessServiceRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUniversityUnitOfWork, UniversityUnitOfWork>();
        }
    }
}
