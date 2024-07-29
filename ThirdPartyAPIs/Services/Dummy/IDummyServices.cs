using ThirdPartyAPIs.Models;
using ThirdPartyAPIs.Models.Dummy;

namespace ThirdPartyAPIs.Services.Dummy
{
    public interface IDummyServices
    {
       public Task<AllProducts> GetAllProduct();
 
       public Task<Product> AddNewProduct(Product add);
       
       public Task<Product> UpdateProduct(int id , Product add);

       public Task<string> DeleteProduct(int id);

       public Task<Log> Login(Login log); 
       public Task<RefreshToken> RefreshToken(string refreshToken);
       

    }
}
