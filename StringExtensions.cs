using System;

namespace test_app
{
    public static class StringExtensions
    {
        public static string ToInxnNetworkServiceType(this string type)
        {
            switch (type)
            {
                case NetworkServiceTypes.P2PVC:
                    return InxnNetworkServiceTypes.VlanConnect;
                case NetworkServiceTypes.CloudVC:
                    return InxnNetworkServiceTypes.CloudService;
                default:
                    throw new Exception("Unrecognized type");
            }
        }
    }
}
