﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            throw new NotImplementedException();
        }
    }
}