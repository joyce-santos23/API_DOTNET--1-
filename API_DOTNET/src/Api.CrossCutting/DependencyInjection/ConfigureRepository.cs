using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root";

            serviceCollection.AddDbContext<MyContext> (
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
                
            
        
        }
    }
}