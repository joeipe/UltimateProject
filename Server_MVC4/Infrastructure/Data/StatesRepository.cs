using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Server_MVC4.Core.Interfaces;
using Server_MVC4.Infrastructure.Data;

namespace Server_MVC4.Infrastructure.Data
{
    public class StatesRepository : SqlRepository<State>, IStatesRepository
    {
        public StatesRepository(DbContext dataContext)
            : base(dataContext) 
        {

        }

        public void EditState(int id, State state)
        {
            var _state = DataTable.Find(id);
            _state.Name = state.Name;
        }
    }
}