namespace ThirdPartyAPIs.Models.Weather.Weather
{
    public class Current
    {
        public decimal temp_c { get; set; }
        public decimal temp_f { get; set; }
        public Conditioncs condition { get; set; }
    }
}
