using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Listicus.Core.Exceptions;
using Listicus.Core.Models;
using Listicus.Core.Utilities;
using Microsoft.Http;

namespace Listicus.Core.Client
{
    public class ListicusRestClient
    {
        private readonly string ListicusRestUrl = ConfigurationManager.AppSettings["ListicusRestUrl"] + "list/";

//        public List<List> GetAllLists()
//        {
//            
//        }

        public List CreateList(List list)
        {
            var serializer = new XmlSerializer(typeof(List), "http://schemas.listicus.com");
            HttpClient client = new HttpClient();
            string listXml = XmlSerializerHelper.SerializeToString(serializer, list);
            HttpResponseMessage returnValue = client.Post(ListicusRestUrl, "text/xml", HttpContent.Create(listXml));
            if (returnValue.StatusCode == HttpStatusCode.OK)
            {
                List returnedOrder = XmlSerializerHelper.DeserializeString<List>(serializer, returnValue.Content.ReadAsString());
                return returnedOrder;
            }
            else
            {
                throw new HttpResponseError(returnValue.StatusCode, returnValue.Content.ReadAsString());
            }
        }
    }
}
