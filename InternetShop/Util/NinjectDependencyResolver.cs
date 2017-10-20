using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetShop.Models;
using System.Web.Mvc;
using Ninject;

namespace InternetShop.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
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
            kernel.Bind<IItemRepository>().To<ItemRepository>();
        }
    }
}