using HealthApp.Models.PrimaryTableFood;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFoodService(userId);
            var model = service.GetPrimaryTableFood();

            return View(model);
        }

        //Get: PrimaryTablFood Create
        public ActionResult Create()
        {
            return View();
        }

        //Get: PrimaryTableFood Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePrimaryFoodTable(FoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFoodTableServices();

            if (service.CreatePrimaryFoodTable(model))
            {
                TempData["SaveResault"] = "Your food plan was saved!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your food plan could not be created.");

            return View(model);
        }

        //Get:PrimaryFoodTable Details
        public ActionResult
            PrimaryTableFoodDetails(int id)
        {
            var svc = CreateFoodTableServices();
            var model = svc.GetPrimaryTableFoodById(id);

            return View(model);
        }
        //Get: PrimaryFoodTable Delete
        [ActionName("Delete")]
        public ActionResult PrimaryTableFoodDelete(int id)
        {
            var svc = CreateFoodTableServices();
            var model = svc.GetPrimaryTableFoodById(id);

            return View(model);
        }

        //Get: PrimaryTableFitness Edit
        public ActionResult PrimaryTableFoodEdit(int id)
        {
            var service = CreateFoodTableServices();
            var detail = service.GetPrimaryTableFoodById(id);
            var model =
                new FoodEdit
                {
                    FoodId = detail.FoodId,
                    FoodName = detail.FoodName,
                    TotalCaloriesConsumed = detail.TotalCaloriesConsumed,
                    FoodContent = detail.FoodContent,
                    DailyWeight = detail.DailyWeight,
                    CupsWaterDrank = detail.CupsWaterDrank,
                    CreatedUtc = detail.CreatedUtc,
                };
            return View(model);
        }

        //Get: PrimaryTableFitness Overload Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrimaryTableFoodEdit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodTableServices();

            if (service.UpdatePrimaryTableFood(model)) //not sure why this is erroring out
            {
                //TempData["SaveResult"] = "Your plan has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan couldnt be edited.");
            return View();
        }

        //Get: PrimaryFoodTable Delete Overload
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodTableServices();

            service.PrimaryTableFoodDelete(id);

            TempData["SaveREsult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private PrimaryTableFoodService CreateFoodTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFoodService(userId);
            return service;
        }
    }
}

//Need to add in the overload edit controller