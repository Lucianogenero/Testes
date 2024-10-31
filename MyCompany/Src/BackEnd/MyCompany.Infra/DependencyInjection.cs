using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Domain.Repository;
using MyCompany.Infra.Repository;
using System.Reflection;

namespace MyCompany.Infra
{
    public static class DependencyInjection
    {
        private static string _connectionString { get; set; } = string.Empty;

        public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            AddDbContext(services, configuration);
            AddDbRepositories(services, configuration);
            AddFluentMigrator(services);
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<MyCompanyDbContext>(configuration.GetSection("DefaultConnection"));
            //services.AddSingleton(sp => sp.GetRequiredService<IOptions<MyCompanyDbContext>>().Value);

            //services.AddDbContext<MyCompanyDbContext>(options => options.UseSqlServer(_connectionString));
        }

        public static void AddDbRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }

        private static void AddFluentMigrator(IServiceCollection services)
        {
            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(_connectionString)
                .ScanIn(Assembly.Load("MyCompany.Infra")).For.All();
            });
        }

    }
}
