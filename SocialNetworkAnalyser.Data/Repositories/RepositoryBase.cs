using SocialNetworkAnalyser.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class RepositoryBase
    {
        protected AppContext Context { get; private set; }


        public RepositoryBase(AppContext context)
        {
            Context = context;
        }
    }
}
