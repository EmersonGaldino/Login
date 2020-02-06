using AutoMapper;
using galdino.humanResource.domain.Entity.Authentication;
using galdino.humanResource.domain.Shared.Base;
using galdino.humanResource.utils.Assinatures;
using galdino.humanResource.Web_cli.Models.Interfaces;
using galdino.humanResource.Web_cli.Models.ModelView;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace galdino.humanResource.Web_cli.Configurations.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile<CustomMappingProfile>();


                //mapeamento das modelviews
                typeof(IViewModel<>).Assembly.GetTypes()?.ToList().Where(vm =>
                    vm.IsAssignableToGenericType(typeof(IViewModel<>)) && !vm.IsInterface
                ).ToList().ForEach(vm => { mc.CreateMap(vm, vm.GetInterfaces()[0].GetGenericArguments()[0]); });
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public class CustomMappingProfile : Profile
        {
            public CustomMappingProfile()
            {
                CreateMap<UserModelView, UserLogin>()
                    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Usuario))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ReverseMap();

                CreateMap<UserViewModel, UserLogin>()
                    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Usuario))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ReverseMap()
                    .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Login))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
                CreateMap<UserModelView, UserViewModel>().ReverseMap();
                CreateMap<UserToken, TokenModelView>().ReverseMap();
            }
        }
    }
}
