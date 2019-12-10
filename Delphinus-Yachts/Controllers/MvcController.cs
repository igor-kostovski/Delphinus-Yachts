using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delphinus_Yachts.Controllers
{
    public class MvcController : Controller
    {
        public ActionResult Index(string entity)
        {
            return View(entity + "/Index");
        }

        public ActionResult Edit(string entity)
        {
            return View(entity + "/Edit");
        }
    }
}