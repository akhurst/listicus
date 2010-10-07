using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Listicus.Core.Client;
using Listicus.Core.Models;
using Listicus.Core.Utilities;

namespace Listicus.RESTClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ListicusRestClient client = new ListicusRestClient();
            List list = new List{Name = "ClientList1"};
            client.CreateList(list);
            Console.WriteLine(XmlSerializerHelper.SerializeToString(list));
        }
    }
}
