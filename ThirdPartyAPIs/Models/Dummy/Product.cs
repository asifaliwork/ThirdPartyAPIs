namespace ThirdPartyAPIs.Models.Dummy
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public decimal price { get; set; } = decimal.Zero;
        public decimal rating { get; set; } = decimal.Zero;
        public string brand { get; set; } = string.Empty;
        public int stock { get; set; }
        public int weight { get; set; }
        public string availabilityStatus { get; set; } = string.Empty;
        public int? quantity { get; set; }


    }
}
