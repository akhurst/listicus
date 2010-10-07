using System.ComponentModel.DataAnnotations;

namespace Listicus.Core.Models
{
    public class Token
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public virtual List List { get; set; }
    }
}
