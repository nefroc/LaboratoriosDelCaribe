using Services.Services;
using Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LabCaribeWeb
{
    public static class IoC
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services) {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IMenuService, MenuService>();

            return services;
        }
    }
}
