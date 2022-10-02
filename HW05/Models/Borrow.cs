using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class Borrow
    {
        public int BorrowID { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime? BroughtDate { get; set; }
        public String FullName { get; set; }
    }
}