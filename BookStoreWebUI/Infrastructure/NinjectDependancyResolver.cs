using BookStoreDomain.Abstract;
using BookStoreDomain.Concrete;
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
            //Mock<IBookRepository> mock= new Mock<IBookRepository>();
            //mock.Setup(b => b.Books).Returns(
            //    new List<Book> {
            //    new Book {Title="SQL",Author="Frank",Description="asw",Price=212 },
            //    new Book { Title="ASP.NET",Author="Sam",Description="asw2",Price=433},
            //    new Book {Title="C#",Author="Hani",Description="asw3",Price=23 } }
            //    );
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
           // kernel.Bind<IBookRepository>().ToConstant(mock);

            // throw new NotImplementedException();
        }
    }
}