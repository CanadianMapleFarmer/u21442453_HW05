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
        public static String searchText = null;
        public static String Class = null;
        private List<Student> students = new List<Student>();
        public ActionResult Index(int id)
        {
            if (searchText != null && Class != null)
            {
                students = ds.getStudentsBySearchAndClass(Class, searchText);
            }
            else if (searchText != null && Class == null)
            {
                students = ds.getStudentsBySearch(searchText);
            }
            else if (searchText == null && Class != null)
            {
                students = ds.getStudentsByClass(Class);
            }
            else if (searchText == null && Class == null)
            {
                students = ds.getAllStudents();
            }
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

        [HttpPost]
        public ActionResult searchStudent(FormCollection f, int bookid)
        {
            String st = f["searchText"];
            String c = f["selectedClass"];
            if (st != "")
            {
                StudentController.searchText = st;
            }
            if (c != "0")
            {
                StudentController.Class = c;
            }

            return RedirectToAction("Index", new { id = bookid});
        }

        public ActionResult clearFilter(int bookid)
        {
            StudentController.Class = null;
            StudentController.searchText = null;
            return RedirectToAction("Index", new { id = bookid});
        }
    }
}
