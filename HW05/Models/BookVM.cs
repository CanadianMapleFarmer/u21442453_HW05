using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class BookVM
    {
        public List<Book> Books { get; set; }
        public List<Type> Types { get; set; }
        public List<Author> Authors { get; set; }
        public List<Status> Statuses { get; set; }
        
    }
}