using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Server_MVC4.Core.Interfaces;

namespace Server_MVC4.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        public INorthwindUow Uow { get; set; }
    }
}