using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace Server_MVC4.Infrastructure.Services
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modeState = actionContext.ModelState;
            if (!modeState.IsValid)
            {
                var errors = new JObject();
                foreach (var key in modeState.Keys)
                {
                    var state = modeState[key];
                    if (state.Errors.Any())
                    {
                        errors[key] = state.Errors.First().ErrorMessage;
                    }
                }

                actionContext.Response = actionContext.Request.CreateResponse<JObject>(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}