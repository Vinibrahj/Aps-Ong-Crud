﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OngCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Inicio() // View Inicial
        {
            return View();
        }
    }
}