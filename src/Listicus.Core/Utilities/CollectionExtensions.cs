using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Listicus.Core.Utilities
{
    public static class CollectionExtensions
    {
        public static bool HasItems(this ICollection c)
        {
            return c != null && c.Count > 0;
        }
    }
}
