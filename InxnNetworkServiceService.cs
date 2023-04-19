using Org.OpenAPITools.Model;
using System;

namespace test_app
{
    public class InxnNetworkServiceService
    {
        public NetworkService CreateVlanConnectService(InxnNetworkServiceDto inxnNetworkServiceDto)
        {
            //perform specific validation

            //do some processing - obtain required response payload fields
            inxnNetworkServiceDto.Id = "VLC_000001";
            //create the response
            return inxnNetworkServiceDto.ToNetworkService();
        }

        public NetworkService CreateVlanConnectServiceWithServiceKey(InxnNetworkServiceDto inxnNetworkServiceDto)
        {
            //perform specific validation

            //do some processing - obtain required response payload fields
            inxnNetworkServiceDto.Id = "VLC_000002";
            //create the response
            return inxnNetworkServiceDto.ToNetworkService();
        }

        public NetworkService CreateCloudService(InxnNetworkServiceDto inxnNetworkServiceDto)
        {
            //perform specific validation

            //do some processing - obtain required response payload fields
            inxnNetworkServiceDto.Id = "CSUK-000001";
            inxnNetworkServiceDto.ProviderRef = "provider-ref";
            //create the response
            return inxnNetworkServiceDto.ToNetworkService();
        }

        public NetworkService CreateInxnNetworkService(InxnNetworkServiceDto serviceDto)
        {
            NetworkService response = null;

            //generic validation goes here

            if (serviceDto.IsP2PVCWithServiceKey())
            {
                response = CreateVlanConnectServiceWithServiceKey(serviceDto);
            }
            else
            {
                switch (serviceDto.Type)
                {
                    case InxnNetworkServiceTypes.CloudService:
                        response = CreateCloudService(serviceDto);
                        break;
                    case InxnNetworkServiceTypes.VlanConnect:
                        response = CreateVlanConnectService(serviceDto);
                        break;
                    default:
                        throw new Exception("Service type not processable");
                }
            }

            return response;
        }
    }
}
