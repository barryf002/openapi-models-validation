using Org.OpenAPITools.Model;
using System;

namespace test_app
{
    public static class InxnNetworkServiceExtensions
    {
        public static NetworkService ToNetworkService(this InxnNetworkServiceDto inxnNetworkServiceDto)
        {
            switch (inxnNetworkServiceDto.Type)
            {
                case InxnNetworkServiceTypes.VlanConnect:
                    return new P2PNetworkService(
                        id: inxnNetworkServiceDto.Id,
                        billingAccount: inxnNetworkServiceDto.BillingAccount,
                        managingAccount: inxnNetworkServiceDto.ManagingAccount,
                        consumingAccount: inxnNetworkServiceDto.ConsumingAccount,
                        type: NetworkServiceTypes.P2PVC
                    );
                case InxnNetworkServiceTypes.CloudService:
                    return new CloudNetworkService(
                        id: inxnNetworkServiceDto.Id,
                        billingAccount: inxnNetworkServiceDto.BillingAccount,
                        managingAccount: inxnNetworkServiceDto.ManagingAccount,
                        consumingAccount: inxnNetworkServiceDto.ConsumingAccount,
                        cloudKey: inxnNetworkServiceDto.CloudKey,
                        providerRef: inxnNetworkServiceDto.ProviderRef,
                        type: NetworkServiceTypes.CloudVC
                    );
                default:
                    throw new Exception("type not supported");
            }
        }
    }
}
