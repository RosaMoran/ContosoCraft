using ContoseCraft.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContoseCraft.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;
        // private ser means that no one else will use it 
        public IEnumerable<Product> Products { get; private set; }

        // IdexModel constructor-- ask for Ilogger to get the products service
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            // to get the products
            Products = ProductService.GetProducts();
        }
    }
}