﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pyrotechnics.Controllers
{
    public class GameController : Controller
    {
        public ActionResult StartNew()
        {
            return View();
        }
    }
}