using Microsoft.AspNetCore.Mvc;
using Sample.Shared.Dtos.AttributeProducts;
using Web.BaseApi;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseApiClient _baseApiClient;
        public ProductController(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }

        public IActionResult Index()
        {
            var products = _baseApiClient.GetAsync<ProductDto>("/api/Product/GetHomeProductCategory", "https://localhost:7003");
            return View();
        }
        public IActionResult ProductDetail(Guid Id)
        {
            var product = _baseApiClient.GetAsync<ProductDto>($"/api/Product/GetById?Id={Id}", "https://localhost:7003");
            ViewData["product"] = product.Result;
            return View();
        }
    }
}
