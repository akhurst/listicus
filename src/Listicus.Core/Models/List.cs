using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Listicus.Core.Models
{
    public class List
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public virtual List<Link> Links { get; set; }
    }
}
