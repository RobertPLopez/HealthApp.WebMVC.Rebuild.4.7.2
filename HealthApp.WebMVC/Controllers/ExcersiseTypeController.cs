using HealthApp.Models.ExcersiseTypeTable;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class ExcersiseTypeController : Controller
    {
        [Authorize]
        // GET: ExcersiseType Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExcersiseTypeServices(userId);
            var model = service.GetExcersiseTypeTable();

            return View(model);
        }

        //Get: ExersiseTypeTable Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: ExcersiseTypeTable Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExcersiseTypeTable(ExcersiseTypeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExcersiseTypeServices();

            if (service.CreateExcersiseTypeTable(model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        //Get: ExcersiseTypeTable Details
        public ActionResult PrimaryExcersiseTypeDetails(int id)
        {
            var svc = CreateExcersiseTypeServices();
            var model = svc.GetExcersiseTypeById(id);

            return View(model);
        }

        //Get: ExcersiseTypeTable Edit
        public ActionResult ExcersiseTypeEdit(int id)
        {
            var service = CreateExcersiseTypeServices();
            var detail = service.GetExcersiseTypeById(id);
            var model =
                new ExcersiseTypeEdit
                {
                    ExcersiseTypeId = detail.ExcersiseTypeId,
                    PreformedMovement = detail.PreformedMovement,
                    ExcersiseName = detail.ExcersiseName,
                };
            return View(model);
        }

        //Get: ExcersiseType Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcersiseTypeEdit(int id, ExcersiseTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ExcersiseTypeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateExcersiseTypeServices();

            if (service.UpdateExcersiseTypeTable(model))
            {
                TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: Excersise Type Table Delete
        [ActionName("Delete")]
        public ActionResult ExcersiseTypeDelete(int id)
        {
            var svc = CreateExcersiseTypeServices();
            var model = svc.GetExcersiseTypeById(id);

            return View(model);
        }

        //Get: Excersise Type Table Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateExcersiseTypeServices();
            service.ExcersiseTypeTableDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private ExcersiseTypeServices CreateExcersiseTypeServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExcersiseTypeServices(userId);
            return service;
        }
    }
}