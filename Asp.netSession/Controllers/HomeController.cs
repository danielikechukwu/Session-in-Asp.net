using Asp.netSession.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asp.netSession.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHttpContextAccessor Context;
        public HomeController(IHttpContextAccessor context)
        {
            Context = context;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //Declaring two variable of the session

            Context.HttpContext.Session.SetString("StudentName","John");

            Context.HttpContext.Session.SetInt32("StudentID", 98);

            return View();
        }

        public IActionResult Privacy()
        {
            string studentName = Context.HttpContext.Session.GetString("StudentName");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}