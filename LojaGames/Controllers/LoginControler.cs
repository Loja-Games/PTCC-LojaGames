﻿using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class LoginControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }
    }
}
