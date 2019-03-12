using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HSJ.Controllers
{
    public class VolunteerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sub1()
        {
            return View();
        }

        public IActionResult Sub2()
        {
            return View();
        }
    }
}