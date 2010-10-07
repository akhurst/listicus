using System.Collections.Generic;
using Listicus.Core.Models;
using Listicus.Core.Utilities;
using Listicus.Web.Models;

namespace Listicus.Web.Helpers
{
    public static class ListMapper
    {
        public static Link CreateLink(this LinkModel model)
        {
            if (model == null)
                return null;

            var link = new Link
                           {
                               Id = model.Id.ToLongOrDefault(),
                               Text = model.Title,
                               Url = model.Url
                           };

            return link;
        }

        public static LinkModel CreateLinkModel(this Link link)
        {
            if (link == null)
                return null;

            var linkModel = new LinkModel
                                {
                                    Id = link.Id.ToString(),
                                    Title = link.Text,
                                    Url = link.Url
                                };

            return linkModel;
        }

        public static List CreateList(this ListModel model)
        {
            var list = new List {Id = model.Id.ToLongOrDefault(), Name = model.Name.ToNullOrValue()};

            if (model.Links != null)
            {
                foreach (LinkModel linkModel in model.Links)
                {
                    AddLinkModelToList(linkModel, list);
                }
            }

            return list;
        }

        public static ListModel CreateListModel(this List list)
        {
            var model = new ListModel();

            model.Id = list.Id.ToString();
            model.Name = list.Name;

            if (list.Links != null)
            {
                foreach (Link link in list.Links)
                {
                    AddLinkToListModel(link, model);
                }
            }

            return model;
        }

        private static void AddLinkModelToList(LinkModel linkModel, List list)
        {
            if (linkModel != null && linkModel.Url.IsValidUrl())
            {
                if (list.Links == null)
                    list.Links = new List<Link>();

                Link link = linkModel.CreateLink();

                list.Links.Add(link);
            }
        }

        private static void AddLinkToListModel(Link link, ListModel listModel)
        {
            if (link != null && link.Url.IsValidUrl())
            {
                if (listModel.Links == null)
                    listModel.Links = new List<LinkModel>();

                LinkModel linkModel = link.CreateLinkModel();

                listModel.Links.Add(linkModel);
            }
        }
    }
}