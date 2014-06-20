using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.DAL.Models;
using MVCLibrary.Core.Interface;
using MVCLibrary.Core.Services;
using MVCLibrary.Core.ViewModels;
using MVCLibrary.Core.Mapping;
using Newtonsoft.Json;

//using System.Net.Http;
//using System.Web.Http;
//using System.Net;

namespace MVCLibrary.Controllers
{
    // .js su se stalno cache-irali pa radi testiranja
    [OutputCache(Duration=0)]
    public class TownController : Controller
    {
        private ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        #region AngularJS Resources
        //[HttpGet]
        public string GetTowns()
        {
            TownListViewModel towns = _townService.GetTownListView();

            return JsonConvert.SerializeObject(towns, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        /*
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Delete(int id)
        {
            if (_townService.Delete(id))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }*/
        #endregion

        #region CRUD Functions
        //
        // GET: /Town/
        public ViewResult Index(string sortOrder)
        {
            // Show all towns
            TownListViewModel townListView = _townService.GetTownListView();

            ViewBag.SortNameParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    townListView.Towns = townListView.Towns.OrderByDescending(r => r.Name);
                    break;
                default:
                    townListView.Towns = townListView.Towns.OrderBy(r => r.Name);
                    break;
            }

            return View(townListView);
        }

        //
        // GET: /Town/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Town/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TownViewModel town)
        {
            if (ModelState.IsValid)
            {
                if (_townService.Insert(town.ConvertToDomain()))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(town);
        }

        //
        // GET: /Town/Edit/5

        public ActionResult Edit(int id)
        {
            TownViewModel townView = _townService.GetTownViewByID(id);
            return View(townView);
        }

        //
        // POST: /Town/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TownViewModel town)
        {
            if (ModelState.IsValid)
            {
                if (_townService.Update(town.ConvertToDomain()))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(town);
        }

        //
        // GET: /Town/Delete/5
        /*
        public ActionResult Delete(int id)
        {
            TownViewModel townView = _townService.GetTownViewByID(id);
            return View(townView);
        }

        //
        // POST: /Town/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_townService.Delete(id))
            {
                return RedirectToAction("Index");
            }

            TownViewModel townView = _townService.GetTownViewByID(id);
            return View(townView);
        }*/
        #endregion

        protected override void Dispose(bool disposing)
        {
            _townService.Dispose();
            base.Dispose(disposing);
        }
    }
}