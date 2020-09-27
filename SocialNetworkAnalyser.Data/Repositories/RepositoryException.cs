using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class RepositoryException : System.Exception
    {
        public RepositoryException(string message)
            : base($"Repository Exception: {message}")
        {
        }

        public RepositoryException(System.Exception exception)
            : base($"Repository Exception: {exception.Message}", exception)
        {

        }
    }
}
