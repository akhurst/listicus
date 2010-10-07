using System.ComponentModel.DataAnnotations;

namespace Listicus.Core.Models
{
    public class Link
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public virtual List List { get; set; }
        public string Text { get; set; }
    }
}
