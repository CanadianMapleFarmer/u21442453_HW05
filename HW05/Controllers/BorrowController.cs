using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW05.Models;

namespace HW05.Controllers
{
    public class BorrowController : Controller
    {
        DBService ds = new DBService();

        public ActionResult Index(int id)
        {
            List<Borrow> borrows = ds.getBorrowsById(id);
            Status status;
            if (!isAvailable(id))
            {
                status = new Status
                {
                    Text = "- Book Out",
                    Style = "red"
                };
            } else
            {
                status = new Status
                {
                    Text = "- Book Available",
                    Style = "green"
                };
            }
            BorrowVM bvm = new BorrowVM {
                title = ds.getBookNamebyId(id),
                bookid = id,
                borrows = borrows,
                status = status
            };

            return View(bvm);
        }

        public bool isAvailable(int id)
        {
            bool available = ds.isAvailable(id);

            return available;
        }

        public ActionResult viewStudents(int id)
        {
            return RedirectToAction("Index", "Student", new { id = id});
        }
    }
}