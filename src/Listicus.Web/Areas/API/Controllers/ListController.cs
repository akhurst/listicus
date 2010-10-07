using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Listicus.Core.Logic;
using Listicus.Core.Models;
using Listicus.Web.Framework;

namespace Listicus.Web.Areas.API.Controllers
{
    public class ListController : Controller
    {
        // Get All Lists
        [HttpGet]
        public ActionResult Index()
        {
            ListLogic listLogic = new ListLogic();
            var lists = listLogic.GetAllLists();
            return new ObjectResult<List<List>>(lists);
        }

        // Create New List
        [HttpPost]
        public ActionResult Index(List list)
        {
            ListLogic listLogic = new ListLogic();
            return new ObjectResult<List>(listLogic.CreateList(list));
        }
    }
}
