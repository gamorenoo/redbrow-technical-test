using Application.Common.Interfaces;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using redbrow_technical_test.Application.Auth.Login;
using redbrow_technical_test.Domain.Users;
using redbrow_technical_test.Infrastructure.Auth;
using redbrow_technical_test.Infrastructure.Persistence;
using redbrow_technical_test.Infrastructure.Repositories.UserRepository;

namespace redbrow_technical_test.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("SqlServerConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IAuthService, AuthService>();

            services.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient(typeof(IQueryRepository<>), typeof(QueryRepository<>));

            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();

            return services;
        }
    }
}
