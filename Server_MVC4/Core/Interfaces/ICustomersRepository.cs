using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server_MVC4.Core.Model;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Core.Interfaces
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        IEnumerable<CustomerDTO> GetAllCountries();
    }
}
