using ContoseCraft.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContoseCraft.Website.Controllers
{
    [Route ("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //ttps://localhost:44350/products/rate?ProductId=jenlooper-cactus&rating=5
        // [HttPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string ProductId, 
            [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }

}
