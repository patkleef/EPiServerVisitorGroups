using System;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Personalization;
using EPiServer.ServiceLocation;
using EPiServerVisitorGroups.Business.IPResolver;

namespace EPiServerVisitorGroups.Business.Initialization
{
    /// <summary>
    /// Ioc container initialization module
    /// </summary>
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    [InitializableModule]
    public class IocContainerInitialization : IConfigurableModule 
    {
        /// <summary>
        /// Configure container
        /// </summary>
        /// <param name="context"></param>
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Container.Configure(x =>
            {
                x.For<IClientIPAddressResolver>().Use<CustomClientIPAddressResolver>();
            });

            StructureMapDependencyResolver resolver = new StructureMapDependencyResolver(context.Container);
            DependencyResolver.SetResolver(resolver);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
        }

        /// <summary>
        /// Preload
        /// </summary>
        /// <param name="parameters"></param>
        public void Preload(string[] parameters)
        {
        }

        /// <summary>
        /// Unitializae
        /// </summary>
        /// <param name="context"></param>
        public void Uninitialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
        }
    }
}