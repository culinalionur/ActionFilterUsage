using ActionFilterUsage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterUsage.Controllers
{
    [Route("api/{merchantCode}/[controller]")]
    [ApiController]
    public class MerchantController : BaseController
    {
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers([FromQuery] string merchantCode)
        {
            return Ok($"Users returned for Merchant {merchantCode}. Page : {Page}, PageSize : {PageSize} ");
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateMerchant(UpdateMerchantRequestModel model)
        {
            return Ok($"Merchant Updated. Name : {model.Name}, Code : {model.MerchantCode}");
        }
    }
}
