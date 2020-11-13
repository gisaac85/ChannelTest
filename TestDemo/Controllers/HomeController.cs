using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLogic;
using SharedLogic.Models.OrderModel;
using TestDemo.Models;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = await AppLogic.GetAllOrder();
          
            return View(model);
        }

        public async Task<IActionResult> GetTopProducts()
        {
            var model = await AppLogic.GetTopProducts(5);
            return View(model);
        }

        public async Task<IActionResult> UpdateStock()
        {
            var model = await AppLogic.UpdateStock();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
