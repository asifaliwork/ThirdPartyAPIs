namespace ThirdPartyAPIs.Models.Dummy
{
    public class Log
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string firstName { get; set; } = string.Empty;
        public string lastName {get; set;}= string.Empty;

        public string gender { get; set; } = string.Empty;

        public string token { get; set; } = string.Empty;

        public string refreshToken { get; set; } = string.Empty;
    }
}
