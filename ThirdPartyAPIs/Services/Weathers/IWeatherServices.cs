using ThirdPartyAPIs.Models.Weather.Weather;

namespace ThirdPartyAPIs.Services.Weathers
{
    public interface IWeatherServices
    {
        public Task<Weather> GetWeatherAsync(string name);
    }
}
