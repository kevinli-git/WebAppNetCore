using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore.Models;

namespace WebAppNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
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

        [HttpPost]
        public IActionResult Save(Account account) {
            if (ModelState.IsValid)
            {
                string jsonString = JsonSerializer.Serialize(account);
                CreateFile(jsonString);

                ViewBag.account = account;
                return View("Success");
            }
            
            return View("Index");
        }

        private void CreateFile(string json) {
            string fileName = Guid.NewGuid().ToString() + ".json";
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Json", fileName);
            System.IO.File.WriteAllText(path, json);
        }
    }
}
