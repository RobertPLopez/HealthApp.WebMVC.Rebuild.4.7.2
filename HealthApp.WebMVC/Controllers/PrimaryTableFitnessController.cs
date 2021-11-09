using HealthApp.Models.PrimaryTableFitness;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class PrimaryTableFitnessController : Controller
    {
        [Authorize]
        // GET: PrimaryTableFitness Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFitnessService(userId);
            var model = service.GetPrimaryTableFitness();

            return View(model);
        }

        //Get: PrimaryTableFitness Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: PrimaryTableFitness Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePrimaryFitnessTable(PrimaryTableFitnessCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePrimaryTableFitnessTableServices();

            if (service.CreatePrimaryFitnessTable(model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        //Get: PrimaryTableFitness Details
        public ActionResult PrimaryTableFitnessDetails(int id)
        {
            var svc = CreatePrimaryTableFitnessTableServices();
            var model = svc.GetPrimaryTableFitnessById(id);

            return View(model);
        }

        //Get: PrimaryTableFitness Edit
        public ActionResult PrimaryTableFitnessEdit(int id)
        {
            var service = CreatePrimaryTableFitnessTableServices();
            var detail = service.GetPrimaryTableFitnessById(id);
            var model =
                new PrimaryTableFitnessEdit
                {
                    WorkoutId = detail.WorkoutId,
                    TotalCaloriesBurned = detail.TotalCaloriesBurned,
                };
            return View(model);
        }

        //Get: PrimaryTableFitness Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrimaryTableFitnessEdit(int id, PrimaryTableFitnessEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WorkoutId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePrimaryTableFitnessTableServices();

            if (service.UpdatePrimaryTableFitness(model))
            {
                TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: PrimaryTableFitness Delete
        [ActionName("Delete")]
        public ActionResult PrimaryTableFitnessDelete(int id)
        {
            var svc = CreatePrimaryTableFitnessTableServices();
            var model = svc.GetPrimaryTableFitnessById(id);

            return View(model);
        }

        //Get: PrimaryTableFitness Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePrimaryTableFitnessTableServices();

                 service.PrimaryTableFitnessDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private PrimaryTableFitnessService CreatePrimaryTableFitnessTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFitnessService(userId);
            return service;
        }
    }
}