namespace test_app
{
    //internal DTO for processing the request as an Interxion network service - one-size-fits-all DTO
    public class InxnNetworkServiceDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string ManagingAccount { get; set; }
        public string ConsumingAccount { get; set; }
        public string BillingAccount { get; set; }
        public string ServiceKey { get; set; }
        public string CloudKey { get; set; }
        public string ProviderRef { get; set; }
        public bool IsP2PVCWithServiceKey()
        {
            return this.Type == InxnNetworkServiceTypes.VlanConnect && !string.IsNullOrEmpty(ServiceKey);
        }
    }
}
