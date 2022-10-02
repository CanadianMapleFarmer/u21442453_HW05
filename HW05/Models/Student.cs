using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class Student
    {

        public int StudentID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public String Gender { get; set; }
        public String Class { get; set; }
        public int Point { get; set; }
    }
}