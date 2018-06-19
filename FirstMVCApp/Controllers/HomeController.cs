using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Controllers
{
    // there is supposed to be 2 index and one result

    public class HomeController : Controller
    {
        // getting info
        [HttpGet]
        // add Index
        public IActionResult Index()
        {
            return View();
        }

        // using info from the user
        [HttpPost]
        // add Index 
        public IActionResult Index(int beginYear, int endYear)
        {
            return View();
        }

        // [Http????]
        // add results redirect??
    }
}
