using FirstMVCApp.Models;
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
        // a redirect to the Results method
        // beingYear is a year the user typed
        // endYear is a year the user typed
        public IActionResult Index(int beginYear, int endYear)
        {
            return RedirectToAction("Results", new { beginYear, endYear});
        }

        // a list with filters
        public IActionResult Results(int beginYear, int endYear)
        {
            TimePeople newPerson = new TimePeople();
            return View(newPerson.GetPeople(beginYear, endYear));
        }
    }
}
