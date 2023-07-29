using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Entities
{
    public class Book
    {
        public Guid Id{ get; set; }
        public string Title{ get; set; }
        public List<Author> Authors{ get; set; }
    }
}