﻿using BookStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWebUI.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}