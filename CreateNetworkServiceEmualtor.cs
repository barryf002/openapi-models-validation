using Newtonsoft.Json;
using Org.OpenAPITools.Model;
using System;

namespace test_app
{
    public class CreateNetworkServiceEmualtor
    {
        public void EmulateP2PVCRequestResponse()
        {
            //post request with required fields
            var request = @"{
                ""type"":""p2p_vc"",
                ""billing_account"": ""A100"",
                ""consuming_account"":""A100"",
                ""managing_account"":""A100""
            }";

            EmulateRequestResponse(request);
        }

        public void EmulateCloudVCRequestResponse()
        {
            //post request with required fields
            var request = @"{
                ""type"":""cloud_vc"",
                ""billing_account"": ""A100"",
                ""cloud_key"":""ck-01111"",
                ""consuming_account"":""A100"",
                ""managing_account"":""A100""
            }";

            EmulateRequestResponse(request);
        }

        private void EmulateRequestResponse(string incomingPayload)
        {
            var mapper = AutomapperConfiguration.GetMapper();
            var inxnNetworkServiceService = new InxnNetworkServiceService();

            try
            {
                var nsReq = JsonConvert.DeserializeObject<NetworkServiceRequest>(incomingPayload);
                var service = mapper.Map<InxnNetworkServiceDto>(nsReq);
                var response = inxnNetworkServiceService.CreateInxnNetworkService(service);
                Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
        }

    }
}
