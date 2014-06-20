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
namespace MVCLibrary.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        #region CRUD Functions
        //
        // GET: /Book/
        public ViewResult Index(string sortOrder)
        {
            // Show all Books
            BookListViewModel bookListView = _bookService.GetBookListView();

            ViewBag.SortNameParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    bookListView.Books = bookListView.Books.OrderByDescending(r => r.Title);
                    break;
                default:
                    bookListView.Books = bookListView.Books.OrderBy(r => r.Title);
                    break;
            }

            return View(bookListView);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            PopulateAuthorsDropDownList();
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                if (_bookService.Insert(book.ConvertToDomain()))
                {
                    return RedirectToAction("Index");
                }
            }

            PopulateAuthorsDropDownList(book.AuthorID);
            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            BookViewModel bookView = _bookService.GetBookViewByID(id);
            PopulateAuthorsDropDownList(bookView.AuthorID);
            return View(bookView);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                if (_bookService.Update(book.ConvertToDomain()))
                {
                    return RedirectToAction("Index");
                }
            }

            PopulateAuthorsDropDownList(book.AuthorID);
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id)
        {
            BookViewModel bookView = _bookService.GetBookViewByID(id);
            return View(bookView);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_bookService.Delete(id))
            {
                return RedirectToAction("Index");
            }

            BookViewModel bookView = _bookService.GetBookViewByID(id);
            return View(bookView);
        }
        #endregion

        private void PopulateAuthorsDropDownList(object selectedAuthor = null)
        {
            AuthorListViewModel authorListView = _authorService.GetAuthorListView();

            ViewBag.AuthorID = new SelectList(authorListView.Authors, "AuthorID", "FullName", selectedAuthor);
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}