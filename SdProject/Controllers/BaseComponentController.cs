﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SdProject.Controllers
{
    public class BaseComponentController : Controller
    {
        public ActionResult Display()
        {
            return View();
        }

    }
}
