﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult ReporteIndex()
        {
            return View();
        }
    }
}