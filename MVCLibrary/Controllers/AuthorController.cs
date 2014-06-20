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

namespace MVCLibrary.Controllers
{
    [OutputCache(Duration = 0)]
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        private ITownService _townService;

        public AuthorController(IAuthorService authorService, ITownService townService)
        {
            _authorService = authorService;
            _townService = townService;
        }

        #region AngularJS Resources
        [HttpGet]
        public string GetAuthors()
        {
            AuthorListViewModel authors = _authorService.GetAuthorListView();

            return JsonConvert.SerializeObject(authors, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public string GetTowns()
        {
            TownListViewModel towns = _townService.GetTownListView();

            return JsonConvert.SerializeObject(towns, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
        #endregion

        #region CRUD Functions
        //
        // GET: /Author/
        public ViewResult Index(string sortOrder)
        {
            // Show all authors
            AuthorListViewModel authorListView = _authorService.GetAuthorListView();

            ViewBag.SortNameParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    authorListView.Authors = authorListView.Authors.OrderByDescending(r => r.LastName);
                    break;
                default:
                    authorListView.Authors = authorListView.Authors.OrderBy(r => r.LastName);
                    break;
            }

            return View(authorListView);
        }

        //
        // GET: /Author/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Author/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                if (_authorService.Insert(author.ConvertToDomain()))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(author);
        }

        //
        // GET: /Author/Edit/5

        public ActionResult Edit(int id)
        {
            AuthorViewModel authorView = _authorService.GetAuthorViewByID(id);

            PopulateAssignedTownData(authorView);

            return View(authorView);
        }

        //
        // POST: /Author/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author, string[] selectedTowns)
        {
            if (ModelState.IsValid)
            {
                // Add TownID foreign key to Author
                Author authorDom = author.ConvertToDomain();
                UpdateAuthorTowns(selectedTowns, authorDom);
                if (_authorService.Update(authorDom))
                {
                    return RedirectToAction("Index");
                }
            }

            PopulateAssignedTownData(author);
            return View(author);
        }

        //
        // GET: /Author/Delete/5

        public ActionResult Delete(int id)
        {
            AuthorViewModel authorView = _authorService.GetAuthorViewByID(id);
            return View(authorView);
        }

        //
        // POST: /Author/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_authorService.Delete(id))
            {
                return RedirectToAction("Index");
            }

            AuthorViewModel authorView = _authorService.GetAuthorViewByID(id);
            return View(authorView);
        }
        #endregion

        private void PopulateAssignedTownData(AuthorViewModel author)
        {
            var allTowns = _townService.GetAll();
            var authorTownIDs = new HashSet<int>(author.Towns.Select(t => t.TownID));
            var assignedView = new List<AssignedTownDataViewModel>();
            foreach (var town in allTowns)
            {
                assignedView.Add(new AssignedTownDataViewModel
                {
                    TownID = town.TownID,
                    Name = town.Name,
                    Assigned = authorTownIDs.Contains(town.TownID)
                });
            }

            ViewBag.Towns = assignedView;
        }

        private void UpdateAuthorTowns(string[] selectedTowns, Author author)
        {
            if (selectedTowns == null)
            {
                author.Towns = new HashSet<Town>();
                return;
            }

            var allTowns = _townService.GetAll();
            var selectedTownsHS = new HashSet<string>(selectedTowns);
            var authorTownIDs = new HashSet<int>(author.Towns.Select(t => t.TownID));

            foreach (var town in allTowns)
            {
                if (selectedTownsHS.Contains(town.TownID.ToString()))
                {
                    if (!authorTownIDs.Contains(town.TownID))
                    {
                        town.Authors.Add(author);
                        author.Towns.Add(town);
                    }
                }
                else
                {
                    if (authorTownIDs.Contains(town.TownID))
                    {
                        author.Towns.Remove(town);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            _authorService.Dispose();
            base.Dispose(disposing);
        }
    }
}