using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStoreDomain.Abstract;
using BookStoreDomain.Entities;
using BookStoreWebUI.Controllers;
using BookStoreWebUI.HTMLHelper;
using BookStoreWebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // test  to verify that app has two pages and there are just three products in each page
            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(new Book[] {
                new Book{ISBN="1",Title="Book1"},
                new Book{ISBN="2",Title="Book2"},
                new Book{ISBN="3",Title="Book3"},
                new Book{ISBN="4",Title="Book4"},
                new Book{ISBN="5",Title="Book5"}

            });
            Bookcontroller controller = new Bookcontroller(mock.Object); // Method we want to test inside this class
            controller.pageSize = 3;

            //Act
            BookListViewModel result = (BookListViewModel)controller.BookView(1).Model;

            //Assert
            Book[] bookArray = result.Books.ToArray();
            Assert.IsTrue(bookArray.Length == 3);
            Assert.AreEqual(bookArray[0].Title, "Book1");
            Assert.AreEqual(bookArray[1].Title, "Book2");
            Assert.AreEqual(bookArray[2].Title, "Book3");


        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo {
                CurrentPage=2,
                TotalItems=14,
                ItemsPerPage=5
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            String expectedResult = "<a class=\"btn btn-default\" href=\"Page1\">1</a>" 
                                   + "<a class=\"btn btn-default btn-Primary Selected\" href=\"Page2\">2</a>"
                                   + "<a class=\"btn btn-default\" href=\"Page3\">3</a>";

            // Act
            String result = myHelper.PageLinks(pagingInfo,pageUrlDelegate).ToString();

            // Assert
            Assert.AreEqual(expectedResult,result);

        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model() {

            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(
                new Book[] {
                new Book { ISBN="12",Title="SQL"},
                new Book { ISBN = "13", Title = "SQL"},
                new Book { ISBN = "14", Title = "SQL"},
                new Book { ISBN = "15", Title = "SQL" },
                new Book { ISBN = "16", Title = "SQL" }
                });

            Bookcontroller controller = new Bookcontroller(mock.Object);
            controller.pageSize = 3;
            // Act

            BookListViewModel result =(BookListViewModel) controller.BookView(2).Model;
            // Assert
            PagingInfo pageinfo = result.PagingInfo;
            Assert.AreEqual(pageinfo.CurrentPage, 2);
            Assert.AreEqual(pageinfo.ItemsPerPage, 3);
            Assert.AreEqual(pageinfo.TotalItems, 5);
            Assert.AreEqual(pageinfo.TotalPage, 2);


        }
    }
}
