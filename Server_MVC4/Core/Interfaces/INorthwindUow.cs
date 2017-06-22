using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server_MVC4.Core.Interfaces
{
    public interface INorthwindUow : IDisposable
    {
        //IRepository<Customer> Customers { get; }
        //IRepository<State> States { get; }
        IStatesRepository States { get; }
        ICustomersRepository Customers { get; }

        void Save();
    }
}
