using BookStoreDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWebUI.Controllers
{
    public class NavController : Controller
    {
        private IBookRepository repository;
         public NavController(IBookRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu()
        {
            IEnumerable<string> cat = repository.Books
                .Select(b => b.Category)
                .Distinct();
               
            return PartialView(cat);
        }
    }
}