using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Listicus.Core.Logic;
using Listicus.Core.Models;

namespace Listicus.Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ListService" in code, svc and config file together.
    public class ListService : IListService
    {
        public List GetList(long listId)
        {
            ListLogic logic = new ListLogic();
            return logic.GetList(listId);
        }
    }
}
