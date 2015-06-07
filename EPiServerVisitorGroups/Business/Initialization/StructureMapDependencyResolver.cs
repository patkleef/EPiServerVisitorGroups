using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;
using HttpDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
using MvcDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace EPiServerVisitorGroups.Business.Initialization
{
    /// <summary>
    /// Structuremap dependency resolver
    /// </summary>
    public class StructureMapDependencyResolver : MvcDependencyResolver, HttpDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
                return GetInterfaceService(serviceType);

            return GetConcreteService(serviceType);
        }

        private object GetConcreteService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        private object GetInterfaceService(Type serviceType)
        {
            return container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}
