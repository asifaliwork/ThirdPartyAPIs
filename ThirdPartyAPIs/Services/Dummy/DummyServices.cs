using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using ThirdPartyAPIs.Models.Dummy;
using static System.Net.WebRequestMethods;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ThirdPartyAPIs.Services.Dummy
{
    public class DummyServices : IDummyServices
    {
        private readonly IHttpClientFactory _client;

        public DummyServices(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<AllProducts> GetAllProduct()
        {
            try
            {
                var httppp = new HttpRequestMessage(HttpMethod.Get, "https://dummyjson.com/products");

                var httpClient = _client.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httppp);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<AllProducts>(contentStream)!;
                    return result;
                }
                else
                {
                    throw new HttpRequestException("***************Location Not Found Try Again******************");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);

            }
        }
        
        public async Task<Product> AddNewProduct(Product add)
        {
            try
            {
                var httppp = "https://dummyjson.com/products/add";
                var nsd = JsonConvert.SerializeObject(new 
                {
                    title = add.title,
                    description = add.description,
                    category = add.category,
                    brand = add.brand,
                    rating = add.rating,
                    stock = add.stock,
                    price = add.price,
                    weight = add.weight,
                    availabilityStatus = add.availabilityStatus,
                    quantity = add.quantity,

                });
                var content = new StringContent(nsd,Encoding.UTF8,"application/json");

                var httpClient = _client.CreateClient();

                var httpResponseMessage = await httpClient.PostAsync(httppp,content);

                httpResponseMessage.EnsureSuccessStatusCode();
                var stringResult = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Product>(stringResult);
                return result;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
        
        public async Task<Product> UpdateProduct(int id, Product add)
        {
            try
            {
                if (id > 0 && id <= 30)
                {
                    var http = $"https://dummyjson.com/products/{id}";
                
                    var nsd = JsonConvert.SerializeObject(new
                    {
                        title = add.title,
                        description = add.description,
                        category = add.category,
                        brand = add.brand,
                        rating = add.rating,
                        stock = add.stock,
                        price = add.price,
                        weight = add.weight,
                        availabilityStatus = add.availabilityStatus,
                        quantity = add.quantity,

                    });
                    var content = new StringContent(nsd, Encoding.UTF8, "application/json");
                    var httpClient = _client.CreateClient();
                    var httpResponseMessage = await httpClient.PutAsync(http, content);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    var stringResult = await httpResponseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Product>(stringResult);
                    return result;
                }
                else
                {
                    throw new HttpRequestException("**************************************     You Can Update between 1 to 30 Ids Only      **********************************");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
        
        public async Task<Log> Login(Login log)
        {
            try
            {
                var http = "https://dummyjson.com/auth/login";
                var logg = JsonConvert.SerializeObject(new
                {
                    username = log.username,
                    password = log.password,
                    expiresInMins = log.expiresInMins,
                });
                var content = new StringContent(logg, Encoding.UTF8, "application/json");
                var httpClient = _client.CreateClient();
                var httpResponseMessage = await httpClient.PostAsync(http , content);
                if (httpResponseMessage.IsSuccessStatusCode) 
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();                
                    var result = JsonSerializer.Deserialize<Log>(contentStream)!;
                    return result;
                }
                else
                {
                    throw new HttpRequestException("***************     User Not Found!       Try Again       ******************");
                }
            }
            catch (Exception ex) 
            {
                throw new HttpRequestException(ex.Message);
            }
        }
        
        public async Task<string> DeleteProduct(int id)
        {
            try
            {
                string result = null!;
                var url = $"https://dummyjson.com/products/{id}";
                var httpClient = _client.CreateClient();
                var httpResponseMessage = await httpClient.DeleteAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                     result = " Id Is delete";                    
                    return result;
                }
                result = " Id Is not delete";             
                return result;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            
        }

        public async Task<RefreshToken> RefreshToken(string refreshToken)
        {
            try
            {
                var url = "https://dummyjson.com/auth/refresh";
                var refesh = JsonConvert.SerializeObject(new
                {
                    refreshToken=refreshToken
                });
                var content = new StringContent(refesh, Encoding.UTF8, "application/json");
                var httpClient = _client.CreateClient();
                var ResponseMessage = await httpClient.PostAsync(url, content);
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await ResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<RefreshToken>(contentStream)!;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
