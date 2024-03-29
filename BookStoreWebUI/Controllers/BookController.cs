﻿using BookStoreDomain.Abstract;
using BookStoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWebUI.Controllers
{
    public class Bookcontroller : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;
        public Bookcontroller(IBookRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        public ViewResult BookView(string category, int pageno = 1)
        {
            BookListViewModel model = new BookListViewModel {
                Books = repository.Books
               .Where(b => category == null || b.Category == category)
               .OrderBy(b => b.ISBN)
               .Skip((pageno - 1) * pageSize)
               .Take(pageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = pageno,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? repository.Books.Count() 
                    : repository.Books
                    .Where(b=>b.Category==category).Count()
                },
                CurrentCategory = category

            };
        return View(model);
        //return View(repository.Books
        // .OrderBy(b => b.ISBN)
        // .Skip((pageno - 1) * pageSize)
        // .Take(pageSize)
        // );
    }

        public ViewResult ListAll()
        {
            return View(repository.Books);
        }
    }
}