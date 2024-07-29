using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdPartyAPIs.Models.Dummy;
using ThirdPartyAPIs.Services.Dummy;

namespace ThirdPartyAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly IDummyServices _dummyServices;

        public DummyController(IDummyServices dummyServices)
        {
            _dummyServices = dummyServices;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Index()
        {
            var result = await _dummyServices.GetAllProduct();

            return Ok(result);
        }

        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddNewProduct([FromBody] Product add)
        {
            var result = await _dummyServices.AddNewProduct(add);

            return Ok(result);
        }

        [HttpPut("UpdateProducts")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product add , int id)
        {
            var result = await _dummyServices.UpdateProduct(id,add);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _dummyServices.DeleteProduct(id);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login add)
        {
            var result = await _dummyServices.Login(add);

            return Ok(result);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefeshToken(string refreshToken)
        {
            var result = await _dummyServices.RefreshToken(refreshToken);

            return Ok(result);
        }

    }
}
