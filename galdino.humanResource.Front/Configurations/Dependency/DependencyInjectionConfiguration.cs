using galdino.humanResource.domain.Interfaeces.User;
using galdino.humanResource.infra.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace galdino.humanResource.Front.Configurations.Dependency
{
    public class DependencyInjectionConfiguration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserIntegration, UserIntegration>(provider => new UserIntegration(configuration.GetValue<string>("ApiConfiguration:URL"),
                configuration.GetValue<string>("ApiConfiguration:Versao")));

            //services.AddScoped<IColaboradorIntegration, ColaboradorIntegration>(provider => new ColaboradorIntegration(configuration.GetValue<string>("ApiConfiguration:URL"),
            //    configuration.GetValue<string>("ApiConfiguration:Versao")));

        }

        private static void RegistrarInterfaces(IServiceCollection services, Type typeBase, string containsInNamespace, string sulfix)
        {
            var types = typeBase
                .Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               type.Namespace.Contains(containsInNamespace) &&
                               type.Name.EndsWith(sulfix) &&
                               !type.IsGenericType &&
                               type.IsClass &&
                               type.GetInterfaces().Any());

            foreach (var type in types)
            {
                var interfaceType = type
                    .GetInterfaces()?
                    .FirstOrDefault(t => t.Name == $"I{type.Name}");
                if (interfaceType == null)
                {
                    continue;
                }
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
