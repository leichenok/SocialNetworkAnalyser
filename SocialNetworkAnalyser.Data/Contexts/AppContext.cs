using SocialNetworkAnalyser.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Contexts
{
    public class AppContext : DbContext
    {
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        public AppContext() : base("AppDbConnection")
        {
        }    
    }
}
