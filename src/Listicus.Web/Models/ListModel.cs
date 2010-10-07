using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Listicus.Core.Models;

namespace Listicus.Web.Models
{
    public class ListModel
    {
        public string Id { get; set;}

        public string Name { get; set; }

        public List<LinkModel> Links { get; set; }
    }
}