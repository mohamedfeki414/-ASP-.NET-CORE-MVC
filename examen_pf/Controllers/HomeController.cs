using examen_pf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace examen_pf.Controllers
{
    public class HomeController : Controller
    {




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
