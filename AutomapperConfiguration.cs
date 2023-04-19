using AutoMapper;
using Org.OpenAPITools.Model;

namespace test_app
{
    public static class AutomapperConfiguration
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NetworkServiceRequest, InxnNetworkServiceDto>()
                    .ForMember(_ => _.Type, ep => ep.MapFrom(_ => _.Type.ToInxnNetworkServiceType()));

                cfg.CreateMap<P2PNetworkServiceRequest, InxnNetworkServiceDto>()
                    .IncludeBase<NetworkServiceRequest, InxnNetworkServiceDto>();

                cfg.CreateMap<CloudNetworkServiceRequest, InxnNetworkServiceDto>()
                    .IncludeBase<NetworkServiceRequest, InxnNetworkServiceDto>();
            });

            return configuration.CreateMapper();
        }
    }
}
