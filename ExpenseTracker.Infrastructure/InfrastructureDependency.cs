using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Contexts;
using ExpenseTracker.Infrastructure.Repositories;
using ExpenseTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddTransient<IExpenseRepository, ExpenseRepository>();
            //service.AddTransient<ICurrentUserService, CurrentUserService>();
            service.AddTransient<IDateTimeService, DateTimeService>();
            return service;
        }

        public static IServiceCollection AddSqlConnection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlite(configuration.GetConnectionString("ConnectionString")
            ));
            return service;
        }
    }
}
