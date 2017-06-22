using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server_MVC4.Core.Interfaces;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Infrastructure.Data
{
    public class NorthwindUow : INorthwindUow
    {
        private NorthwindEntities context;

        //public IRepository<State> States { get { return new SqlRepository<State>(context); } }
        //public IRepository<Customer> Customers { get { return new SqlRepository<Customer>(context); } }
        public IStatesRepository States { get { return new StatesRepository(context); } }
        public ICustomersRepository Customers { get { return new CustomersRepository(context); } }


        public NorthwindUow()
        {
            CreateDbContext();
        }

        private void CreateDbContext()
        {
            context = new NorthwindEntities();
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}