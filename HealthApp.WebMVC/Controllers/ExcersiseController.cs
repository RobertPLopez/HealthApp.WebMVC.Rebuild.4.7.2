using HealthApp.Models.ExcersiseTable;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class ExcersiseController : Controller
    {
        [Authorize]
        // GET: Excersise Table Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExcersiseTableService(userId);
            var model = service.GetExcersiseTable();

            return View(model);
        }

        //Get: ExcersiseTable Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: ExcersiseTable Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExcersiseTable(ExcersiseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExcersiseTableServices();

            if (service.CreateExcersiseTable(model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        //Get: ExcersiseTable Details
        public ActionResult ExcersiseTableDetails(int id)
        {
            var svc = CreateExcersiseTableServices();
            var model = svc.GetExcersiseTableById(id);

            return View(model);
        }

        //Get: ExcersiseTable Edit
        public ActionResult ExcersiseTableEdit(int id)
        {
            var service = CreateExcersiseTableServices();
            var detail = service.GetExcersiseTableById(id);
            var model =
                new ExcersiseEdit
                {
                    OwnerId = detail.OwnerId,
                    ExcersiseId = detail.ExcersiseId,
                    WorkoutId = detail.WorkoutId,
                    ExcersiseTypeId = detail.ExcersiseTypeId,
                };
            return View(model);
        }

        //Get: ExcersiseTable Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcersiseTableEdit(int id, ExcersiseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ExcersiseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateExcersiseTableServices();

            if (service.UpdateExcersiseTable(model)) 
            {
               TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: ExcersiseTable Delete
        [ActionName("Delete")]
        public ActionResult PrimaryTableFitnessDelete(int id)
        {
            var svc = CreateExcersiseTableServices();
            var model = svc.GetExcersiseTableById(id);

            return View(model);
        }

        //Get: ExcersiseTable Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateExcersiseTableServices();

            service.ExcersiseTableDelete(id);

            TempData["SaveREsult"] = "Your excersises were deleted";

            return RedirectToAction("Index");
        }





        private ExcersiseTableService CreateExcersiseTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExcersiseTableService(userId);
            return service;
        }
    }
}