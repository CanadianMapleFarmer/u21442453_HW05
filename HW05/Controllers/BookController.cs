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
        public static String typeid = null;
        public static String authorid = null;
        private List<Book> books = new List<Book>();

        public ActionResult Index()
        {
            if (typeid != null && searchText != null && authorid != null)
            {
                books = ds.getAllBooksByTypeAuthorAndSearchText(authorid, typeid, searchText);
            }
            else if(typeid != null && searchText != null && authorid == null)
            {
                books = ds.getAllBooksByTypeIdAndSearchText(typeid, searchText);
            }
            else if (typeid == null && searchText != null && authorid != null)
            {
                books = ds.getAllBooksByAuthorIdAndSearchText(authorid, searchText);
            }
            else if (typeid != null && searchText == null && authorid != null)
            {
                books = ds.getAllBooksByAuthorAndTypeId(authorid, typeid);
            }
            else if (typeid != null && searchText == null && authorid == null)
            {
                books = ds.getAllBooksByTypeId(typeid);
            }
            else if (typeid == null && searchText == null && authorid != null)
            {
                books = ds.getAllBooksByAuthorId(authorid);
            }
            else if (typeid == null && searchText != null && authorid == null)
            {
                books = ds.getAllBooksBySearchText(searchText);
            }
            else if (typeid == null && authorid == null && searchText == null)
            {
                books = ds.getAllBooks();
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

        [HttpPost]
        public ActionResult searchBook(FormCollection f)
        {
            String st = f["searchText"];
            String typeId = f["selectedType"];
            String authorId = f["selectedAuthor"];
            if(st != "")
            {
                BookController.searchText = st;
            }
            if (typeId != "0")
            {
                BookController.typeid = typeId;
            }
            if (authorId != "0")
            {
                BookController.authorid = authorId;
            }

            return RedirectToAction("Index");
        }

        public ActionResult clearFilter()
        {
            BookController.searchText = null;
            BookController.typeid = null;
            BookController.authorid = null;
            return RedirectToAction("Index");
        }
    }
}