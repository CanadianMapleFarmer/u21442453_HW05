using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class BorrowVM
    {
        public String title { get; set; }
        public int bookid { get; set; }
        public List<Borrow> borrows { get; set; }
        public Status status { get; set; }
    }
}