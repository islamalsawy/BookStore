using BookStoreDomain.Abstract;
using BookStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDomain.Concrete
{
   public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get
            {         
                return context.Books;
            }
        }

        
    }
}
