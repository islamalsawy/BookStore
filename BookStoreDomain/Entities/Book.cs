using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDomain.Entities
{
    class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }    
        public int Price { get; set; }



    }
}
