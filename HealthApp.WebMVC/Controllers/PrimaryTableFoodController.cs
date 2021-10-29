using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class PrimaryTableFoodController : Controller
    {
        // GET: PrimaryTableFood
        public ActionResult Index()
        {
            return View();
        }
    }
}