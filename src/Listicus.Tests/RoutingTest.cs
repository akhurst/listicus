using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Listicus.Web;
using Listicus.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;

namespace Listicus.Tests
{
    [TestClass]
    public class RoutingTest
    {
        [TestInitialize]
        public void SetUp()
        {
            RouteTable.Routes.Clear();
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [TestMethod]
        public void HandleControllerActionIdUrl()
        {
            "~/list/index/6".Route().ShouldMapTo<ListController>(c => c.Index("6"));
        }

        [TestMethod]
        public void HandleControllerActionUrl()
        {
            "~/home/about".ShouldMapTo<HomeController>(c => c.About());
        }

        [TestMethod]
        public void HandleControllerActionDefaultIdUrl()
        {
            "~/list/index".ShouldMapTo<ListController>(c => c.Index());
        }

        [TestMethod]
        public void HandleControllerDefaultActionIdUrl()
        {
            "~/list/6".Route().ShouldMapTo<ListController>(c => c.Index("6"));
        }

        [TestMethod]
        public void HandleControllerDefaultActionDefaultIdUrl()
        {
            "~/home".ShouldMapTo<HomeController>(c => c.Index());
        }

        [TestMethod]
        public void HandleControllerDefaultActionUrl()
        {
            "~/test".ShouldMapTo<TestController>(c => c.Index());
        }

        [TestMethod]
        public void HandleListControllerDefaultActionUrl()
        {
            "~/list".Route().ShouldMapTo<ListController>(c => c.Index());
        }

        [TestMethod]
        public void HandleDefaultControllerDefaultActionDefaultIdUrl()
        {
            "~/".ShouldMapTo<HomeController>(c => c.Index());
        }

        [TestMethod]
        public void HandleDefaultControllerDefaultActionIdUrl()
        {
            "~/6".ShouldMapTo<HomeController>(c => c.Index("6"));
        }
    }
}
