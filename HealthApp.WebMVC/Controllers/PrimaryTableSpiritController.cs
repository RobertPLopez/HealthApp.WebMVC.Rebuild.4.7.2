using HealthApp.Models.PrimaryTableSpirit;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class PrimaryTableSpiritController : Controller
    {
        [Authorize]
        // GET: PrimaryTableSpirit Indez
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableSpiritService(userId);
            var model = service.GetPrimarySpiritTable();

            return View(model);
        }

        //Get: PrimaryTableSpirit Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: PrimaryTableSpirit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpiritTable(SpiritCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpiritTableServices();

            if (service.CreateSpiritTable(model))
            {
                TempData["SaveResault"] = "Your spirit plan was saved!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your spirit plan could not be created.");

            return View(model);
        }

        //Get:PrimarySpiritTable Details
        public ActionResult
            PrimaryTableSpiritDetails(int id)
        {
            var svc = CreateSpiritTableServices();
            var model = svc.GetPrimarySpiritTableById(id);

            return View(model);
        }

        //Get: PrimaryTableSpirit Edit
        public ActionResult PrimaryTableSpiritEdit(int id)
        {
            var service = CreateSpiritTableServices();
            var detail = service.GetPrimarySpiritTableById(id);
            var model =
                new SpiritEdit
                {
                    HowIViewMe = detail.HowIViewMe,
                    HowIViewOthers = detail.HowIViewOthers,
                    HowOtherPerceiveMe = detail.HowOtherPerceiveMe,
                    MySocialCircle = detail.MySocialCircle,
                    MyRestHours = detail.MyRestHours,
                    OutsideMotivation = detail.OutsideMotivation,
                    InternalMotivaiton = detail.InternalMotivaiton,
                    CreatedUtc = detail.CreatedUtc,
                    ModifiedUtc = DateTimeOffset.Now
                };
            return View(model);
        }

        //Get: PrimaryTableSpirit Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrimaryTableSpiritEdit(int id, SpiritEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HowIViewMe != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSpiritTableServices();

            if (service.UpdateSpiritTable(model)) //not sure why this is erroring out
            {
                //TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: PrimarySpiritTable Delete
        [ActionName("Delete")]
        public ActionResult PrimaryTableSpiritDelete(int id)
        {
            var svc = CreateSpiritTableServices();
            var model = svc.GetPrimarySpiritTableById(id);

            return View(model);
        }

        //Get: PrimarySpiritTable Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSpiritTableServices();

            service.PrimaryTableSpiritDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private PrimaryTableSpiritService CreateSpiritTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableSpiritService(userId);
            return service;
        }
    }
}