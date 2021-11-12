using HealthApp.Models.SetsDataTable;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class SetsController : Controller
    {
        [Authorize]
        // GET: Sets Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SetsServices(userId);
            var model = service.GetSetsTable();

            return View(model);
        }

        //Get: Sets table create
        public ActionResult Create()
        {
            return View();
        }

        //Get: Sets Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSetsTable(SetsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSetServicesTableServices();

            if (service.CreateSetsTable (model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        //Get: Set  table details
        public ActionResult SetsTableDetails(int id)
        {
            var svc = CreateSetServicesTableServices();
            var model = svc.GetSetTableById(id);

            return View(model);
        }

        //Get: Set table Edit
        public ActionResult SetsTablesEdit(int id)
        {
            var service = CreateSetServicesTableServices();
            var detail = service.GetSetTableById(id);
            var model =
                new SetsEdit
                {
                    SetId = detail.SetId,
                    RepsPerSet = detail.RepsPerSet,
                    Weight = detail.Weight,
                    DistanceRan = detail.DistanceRan,
                    TimeRan = detail.TimeRan,
                };
            return View(model);
        }

        //Get: Sets Table Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetsTablesEdit(int id, SetsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSetServicesTableServices();

            if (service.UpdateSetsTable(model))
            {
                TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: Sets table delete
        [ActionName("Delete")]
        public ActionResult SetsTableDelete(int id)
        {
            var svc = CreateSetServicesTableServices();
            var model = svc.GetSetTableById(id);

            return View(model);
        }

        //Get: Sets Table Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSetServicesTableServices();

            service.SetsTableDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private SetsServices CreateSetServicesTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SetsServices(userId);
            return service;
        }
    }
}