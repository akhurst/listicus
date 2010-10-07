using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Listicus.Core.Data;
using Listicus.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Listicus.Tests
{
    [TestClass]
    public class DataUtility
    {
        [TestMethod]
        public void TestListLists()
        {
            using (var context = new ListicusDataContext())
            {
                var list = new List {Name = "test"};
                context.Lists.Add(list);
                context.SaveChanges();
            }
        }
    }
}
