using BookStoreDomain.Abstract;
using BookStoreDomain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;



namespace BookStoreWebUI.Infrastructure
{
    public class NinjectDependancyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependancyResolver( IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<IBookRepository> mock= new Mock<IBookRepository>();
            mock.Setup(b => b.Books).Returns(
                new List<Book> {
                new Book {Title="SQL",Author="Frank" },
                new Book { Title="ASP.NET",Author="Sam"},
                new Book {Title="C#",Author="Hani" } }
                );
            kernel.Bind<IBookRepository>().ToConstant(mock.Object);
            // throw new NotImplementedException();
        }
    }
}