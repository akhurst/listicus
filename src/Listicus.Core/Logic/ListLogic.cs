using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Listicus.Core.Data;
using Listicus.Core.Interfaces.Logic;
using Listicus.Core.Models;
using Listicus.Core.Utilities;

namespace Listicus.Core.Logic
{
    public class ListLogic : IListLogic
    {
        private ListicusDataContext context = new ListicusDataContext();

        public List<List> GetAllLists()
        {
            return context.Lists.ToList();
        }

        public List CreateList(List list)
        {
            if (!list.Links.HasItems())
                return null;

            context.Lists.Add(list);
            context.SaveChanges();
            return list;
        }

        public List GetList(long listId)
        {
            List list = context.Lists.Single(l => l.Id == listId);
            return list;
        }
    }
}
