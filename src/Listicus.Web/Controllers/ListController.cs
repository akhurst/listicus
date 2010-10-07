using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Listicus.Core.Logic;
using Listicus.Core.Models;
using Listicus.Core.Utilities;
using Listicus.Web.Helpers;
using Listicus.Web.Models;
using MvcContrib;

namespace Listicus.Web.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        public ActionResult Index(string id)
        {
            long longId = id.ToLongOrDefault();
            ListLogic listLogic = new ListLogic();
            List list = listLogic.GetList(longId);
            ListModel listModel = list.CreateListModel();

            return View(listModel);
        }
    }
}
