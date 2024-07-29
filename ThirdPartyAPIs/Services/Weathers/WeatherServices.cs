using System.Text.Json;
using Microsoft.Net.Http.Headers;
using ThirdPartyAPIs.Models.Weather.Weather;

namespace ThirdPartyAPIs.Services.Weathers
{
    public class WeatherServices : IWeatherServices
    {
        private readonly IHttpClientFactory _client;

        public WeatherServices(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<Weather> GetWeatherAsync(string name)
        {
            try
            {
                string apiKey = "c21ccdd6f0d9446c9fb62724242607";

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,

                $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={name}")
                {
                    Headers =
                    {
                        { HeaderNames.Accept, "application/json"  }
                    }
                };

                var httpClient = _client.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<Weather>(contentStream);
                    return result!;
                }
                else
                {
                    throw new HttpRequestException("***************Location Not Found Try Again******************");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);

                //throw new HttpRequestException("/////////////////////Location Not Found//////////////////////");
            }

        }
    }
}



