using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW05.Models;

namespace HW05.Controllers
{
    public class StudentController : Controller
    {
        DBService ds = new DBService();

        public ActionResult Index(int id)
        {
            List<Student> students = ds.getAllStudents();
            List<Class> classes = ds.getAllClasses();
            bool isavail = ds.isAvailable(id);
            int? bstudentid = (isavail ? null : (int?) ds.getBorrowStudentbyId(id).studentid);
            int? bborrowid = (isavail ? null : (int?) ds.getBorrowStudentbyId(id).borrowid);
            StudentVM svm;
            svm = new StudentVM
            {
                students = students,
                classes = classes,
                bookid = id,
                studentid = bstudentid,
                borrowid = bborrowid,
                isavailable = isavail
            };
            return View(svm);
        }

        public ActionResult BorrowBook(int studentid, int bookid)
        {
            ds.borrowBook(studentid, bookid);

            return RedirectToAction("Index", new { id = bookid});
        }

        public ActionResult ReturnBook(int borrowid, int bookid)
        {
            ds.returnBook(borrowid);
            return RedirectToAction("Index", new { id = bookid });
        }
    }
}
