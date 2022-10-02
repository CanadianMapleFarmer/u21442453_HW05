using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HW05.Models;

namespace HW05.Controllers
{
    public class BookController : Controller
    {
        private DBService ds = new DBService();
        public static String searchText = null;
        public static int? typeid = null;
        public static int? authorid = null;
        private List<Book> books = new List<Book>();

        public ActionResult Index()
        {
            if (typeid == null && authorid == null)
            {
                books = ds.getAllBooks();
            } else if (typeid != null)
            {
                books = ds.getAllBooksByTypeId(Convert.ToInt32(BookController.typeid));
            } else if (authorid != null)
            {
                books = ds.getAllBooksByAuthorId(Convert.ToInt32(BookController.authorid));
            }

            List<Author> authors = ds.getAllAuthors();

            List<Models.Type> types = ds.getAllTypes();

            List<Status> statuses = new List<Status>();

            foreach (var book in books)
            {
                if (isAvailable(book.BookID))
                {
                    statuses.Add(new Status
                    {
                        Text = "Available",
                        Style = "green"
                    });
                } else
                {
                    statuses.Add(new Status
                    {
                        Text = "Out",
                        Style = "red"
                    });
                }
            }

            BookVM bvm = new BookVM
            {
                Books = books,
                Authors = authors,
                Types = types,
                Statuses = statuses
            };


            return View(bvm);
        }

        public bool isAvailable(int id)
        {
            bool available = ds.isAvailable(id);

            return available;
        }

        public ActionResult viewBook(int id)
        {
            return RedirectToAction("Index", "Borrow", new { id = id });
        }

        public ActionResult setTypeFilter(int typeid)
        {
            BookController.typeid = typeid;
            return RedirectToAction("Index");
        }

        public ActionResult setAuthorFilter(int authorid)
        {
            BookController.authorid = authorid;
            return RedirectToAction("Index");
        }

        public ActionResult clearFilter()
        {
            BookController.typeid = null;
            BookController.authorid = null;
            return RedirectToAction("Index");
        }
    }
}