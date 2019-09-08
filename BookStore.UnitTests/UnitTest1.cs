using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BookStoreDomain.Abstract;
using BookStoreDomain.Entities;
using BookStoreWebUI.Controllers;
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
            IEnumerable<Book> result = (IEnumerable<Book>)controller.BookView(1).Model;

            //Assert
            Book[] bookArray = result.ToArray();
            Assert.IsTrue(bookArray.Length == 3);
            Assert.AreEqual(bookArray[0].Title, "Book1");
            Assert.AreEqual(bookArray[1].Title, "Book2");
            Assert.AreEqual(bookArray[2].Title, "Book3");


        }
    }
}
