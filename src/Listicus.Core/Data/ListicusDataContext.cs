using System.Configuration;
using System.Data.Entity;
using Listicus.Core.Models;

namespace Listicus.Core.Data
{
    public class ListicusDataContext : DbContext
    {
        public ListicusDataContext() : base(ConfigurationManager.ConnectionStrings["ListicusConnection"].ConnectionString)
        {
            
        }

        public DbSet<List> Lists
        {
            get; set;
        }

        public DbSet<Link> Links
        {
            get; set;
        }

        public DbSet<Token> Tokens
        {
            get; set;
        }
    }
}
