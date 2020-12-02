using FreeRecycle.Data.Models;
using FreeRecycle.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeRecycle.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemData db;
        public ItemsController(IItemData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);


            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {

            if (ModelState.IsValid)
            {
                db.Add(item);
                return RedirectToAction("Details", new  { Id = item.Id });
            }
            return View();

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = db.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Update(item);
                return RedirectToAction("Details", new { Id = item.Id });
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");

            }
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }


    }
}