using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server_MVC4.Core.Interfaces;
using Server_MVC4.Core.Model;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        //private IRepository<Customer> repository = null;
        //private INorthwindUow _uow;

        public CustomerController(INorthwindUow uow)
        {
            //this.repository = new SqlRepository<Customer>(new NorthwindEntities());
            Uow = uow;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            //return repository.GetAll().ToList();
            return Uow.Customers.GetAll().ToList();
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetAllCountries()
        {
            return Uow.Customers.GetAllCountries().ToList<CustomerDTO>();
        }

        [HttpGet]
        public HttpResponseMessage GetCustomersByCountry(string country)
        {
            HttpResponseMessage msg = null;
            //var customers = repository.SearchFor(c => c.Country == country);
            var customers = Uow.Customers.SearchFor(c => c.Country == country);

            if (customers == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customers not found");
            }
            else
            {
                msg = Request.CreateResponse<IEnumerable<Customer>>(HttpStatusCode.OK, customers);
            }

            return msg;
        }
    }
}
