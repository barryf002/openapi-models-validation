namespace test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var emualtor = new CreateNetworkServiceEmualtor();
            emualtor.EmulateCloudVCRequestResponse();
            emualtor.EmulateP2PVCRequestResponse();
        }
    }
}
