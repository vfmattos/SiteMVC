﻿using Microsoft.AspNetCore.Mvc;

namespace SiteMVC.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
