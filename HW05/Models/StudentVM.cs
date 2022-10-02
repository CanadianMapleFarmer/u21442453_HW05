using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class StudentVM
    {
        public List<Student> students { get; set; }
        public List<Class> classes { get; set; }
        public int bookid { get; set; }
        public bool isavailable { get; set; }
        public int? studentid { get; set; }
        public int? borrowid { get; set; }
    }
}