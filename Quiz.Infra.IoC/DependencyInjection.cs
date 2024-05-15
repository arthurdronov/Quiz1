using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Interfaces;
using Quiz.Application.Mappings;
using Quiz.Application.Services;
using Quiz.Domain.Interfaces;
using Quiz.Infra.Data.Context;
using Quiz.Infra.Data.Repositories;

namespace Quiz.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ILoginRepository, LoginRepository>();
			services.AddScoped<ILoginService, LoginService>();
			services.AddScoped<IUserQuestionRepository, UserQuestionRepository>();
			services.AddScoped<IUserQuestionService, UserQuestionService>();
			services.AddScoped<IPerfilRepository, PerfilRepository>();
			services.AddScoped<IPerfilService, PerfilService>();
			services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
