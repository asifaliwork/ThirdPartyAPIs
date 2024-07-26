using ThirdPartyAPIs.Models;

namespace ThirdPartyAPIs.Services
{
    public interface IWeatherServices
    {
        public Task<Weather> GetWeatherAsync(string name);
    }
}
