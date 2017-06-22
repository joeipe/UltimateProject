using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Server_MVC4.Core.Interfaces;
using Server_MVC4.Core.Model;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Infrastructure.Data
{
    public class CustomersRepository : SqlRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(DbContext dataContext)
            : base(dataContext)
        {

        }

        public IEnumerable<CustomerDTO> GetAllCountries()
        {
            var countries = (from c in DataTable
                            group c by c.Country into g
                            select new CustomerDTO()
                            {
                                Country = g.Key
                            }).Distinct().ToList<CustomerDTO>();

            return countries;
        }
    }
}