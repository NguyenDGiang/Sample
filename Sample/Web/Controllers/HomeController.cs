using Microsoft.AspNetCore.Mvc;
using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Dtos.Products;
using System.Diagnostics;
using Web.BaseApi;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseApiClient _baseApiClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IBaseApiClient baseApiClient)
        {
            _logger = logger;
            _baseApiClient = baseApiClient;
        }

        public IActionResult Index()
        {
            var products = _baseApiClient.GetListAsync<GetHomeProductCategoryDto>("/api/Product/GetHomeProductCategory", "https://localhost:7003");
            ViewData["products"] = products.Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}