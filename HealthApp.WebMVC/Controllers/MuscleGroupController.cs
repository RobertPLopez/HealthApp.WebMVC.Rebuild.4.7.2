using HealthApp.Models.MuscleGroupTable;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class MuscleGroupController : Controller
    {
        [Authorize]
        // GET: Muscle Groups Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MuscleGroupServices(userId);
            var model = service.GetMuscleGroupTable();

            return View(model);
        }

        //Get: Muscle Groups Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: Muscle Groups Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMuscleGroupTable(MuscleGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMuscleGroupsServices();

            if (service.CreateMuscleGroupTable(model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        //Get: Muscle Groups Details
        public ActionResult MuscleGroupsDetails(int id)
        {
            var svc = CreateMuscleGroupsServices();
            var model = svc.GetMuscleGroupTableyId(id);

            return View(model);
        }

        //Get: Muscle Groups Edit
        public ActionResult MuscleGroupsEdit(int id)
        {
            var service = CreateMuscleGroupsServices();
            var detail = service.GetMuscleGroupTableyId(id);
            var model =
                new MuscleGroupEdit
                {
                    MuscleGroupWorkedName = detail.MuscleGroupWorkedName,
                };
            return View(model);
        }

        //Get: Muscle Groups Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MuscleGroupsEdit(int id, MuscleGroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MuscleGroupWorkedNameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMuscleGroupsServices();

            if (service.UpdateMucsleGroupTable(model))
            {
                TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: Muscle Groups Delete
        [ActionName("Delete")]
        public ActionResult MuscleGroupsDelete(int id)
        {
            var svc = CreateMuscleGroupsServices();
            var model = svc.GetMuscleGroupTableyId(id);

            return View(model);
        }

        //Get: Muscle Groups Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMuscleGroupsServices();

            service.MuscleGroupTableDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private MuscleGroupServices CreateMuscleGroupsServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MuscleGroupServices(userId);
            return service;
        }
    }
}