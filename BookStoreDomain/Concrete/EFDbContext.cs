using BookStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDomain.Concrete
{
    public class EFDbContext :DbContext
    {
 public DbSet<Book> Books { get; set; }

    }
}
