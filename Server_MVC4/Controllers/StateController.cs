using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Server_MVC4.Core.Interfaces;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Controllers
{
    public class StateController : ApiControllerBase
    {
        public StateController(INorthwindUow uow)
        {
            Uow = uow;
        }

        // GET api/state
        [HttpGet]
        public IEnumerable<State> GetStates()
        {
            return Uow.States.GetAll().ToList();
        }

        // GET api/state/5
        [HttpGet]
        public HttpResponseMessage GetState(int id)
        {
            HttpResponseMessage msg = null;
            State state;

            state = Uow.States.GetById(id);

            if (state == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "State not found!");
            }
            else
            {
                msg = Request.CreateResponse<State>(HttpStatusCode.OK, state);
            }
            return msg;
        }

        // POST api/state
        [HttpPost]
        public HttpResponseMessage AddState([FromBody]State state)
        {
            Uow.States.Add(state);
            Uow.Save();

            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "");

            return msg;
        }

        // PUT api/state/5
        [HttpPut]
        public HttpResponseMessage EditState(int id, [FromBody]State state)
        {
            Uow.States.EditState(id, state);
            Uow.Save();

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE api/state/5
        [HttpDelete]
        public HttpResponseMessage DeleteState(int id)
        {
            Uow.States.Delete(id);
            Uow.Save();

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
