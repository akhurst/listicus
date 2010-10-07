using System;
using System.IO;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Listicus.Web.Framework
{
    public class ObjectFilter : ActionFilterAttribute
    {
        public string Param { get; set; }
        public Type RootType { get; set; }

        #region IActionFilter Members

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.ContentType ?? string.Empty)
                .Contains("application/json"))
            {
                object o = new DataContractJsonSerializer(RootType)
                    .ReadObject(filterContext.HttpContext.Request.InputStream);
                filterContext.ActionParameters[Param] = o;
            }
            else
            {
                var xmlRoot = XElement.Load(new StreamReader(
                    filterContext.HttpContext.Request.InputStream,
                    filterContext.HttpContext.Request.ContentEncoding));

                object o = new XmlSerializer(RootType)
                    .Deserialize(xmlRoot.CreateReader());
                filterContext.ActionParameters[Param] = o;
            }
        }

        #endregion
    }
}