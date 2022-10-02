using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public String Name { get; set; }
        public int PageCount { get; set; }
        public int Point { get; set; }
        public String Author { get; set; }
        public String Type { get; set; }
    }
}