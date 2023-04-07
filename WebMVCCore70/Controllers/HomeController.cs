using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCCore70.Models;

namespace WebMVCCore70.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusinessDbContext _context;

        public HomeController(BusinessDbContext context)
        {
           _context = context;
        }

        public IActionResult Index()
        {
            List<Client> clients = _context.Clients.ToList();
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