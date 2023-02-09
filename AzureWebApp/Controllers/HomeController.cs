using System.Diagnostics;
using AzureWebApp.Models;
using AzureWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = _productService.GetProducts();
        var isBeta = await _productService.IsBetaAsync();
        var model = new IndexModel
        {
            Products = products,
            IsBeta = isBeta
        };
        return View(model);
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