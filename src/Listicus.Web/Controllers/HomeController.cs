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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return
                View(new ListModel { Links = new List<LinkModel> { new LinkModel(), new LinkModel(), new LinkModel() } });
        }

        public ActionResult Index(string id)
        {
            return this.RedirectToAction<ListController>(c => c.Index(id));
        }

        [HttpPost]
        public ActionResult Index(ListModel listModel)
        {
            List newList = listModel.CreateList();
            ListLogic listLogic = new ListLogic();
            List persistedList = listLogic.CreateList(newList);

            return this.RedirectToAction<ListController>(c => c.Index(persistedList.Id.ToString()));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
