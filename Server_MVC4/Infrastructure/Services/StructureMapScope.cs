using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Server_MVC4.Infrastructure.Services
{
    public class StructureMapScope : IDependencyScope
    {
        private readonly IContainer _container;

        public StructureMapScope(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return this._container.TryGetInstance(serviceType);
            }

            return this._container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this._container.Dispose();
        }
    }
}