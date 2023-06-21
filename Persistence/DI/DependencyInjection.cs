using Application.Interfaces;
using Application.Interfaces.CommandType;
using Application.Interfaces.QueryType;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands;
using Persistence.Database;
using Persistence.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            // Configure Dapper with Connection String 
            services.AddTransient<IDbConnection>( b => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            //---------------- Command Type Services
            // Product
            services.AddScoped<IProductCommandType,ProductCommandType>();



            //---------------- Query Type Services
            // Product
            services.AddScoped<IProductQueryType, ProductQueryType>();

            return services;
        }
    }
}
