using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Server_MVC4.Infrastructure.Services
{
    public class StructureMapDependencyResolver : StructureMapScope, IDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this._container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this._container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }
    }
}