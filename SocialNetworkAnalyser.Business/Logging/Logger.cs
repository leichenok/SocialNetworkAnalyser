using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Business.Logging
{
    public class Logger
    {
        private static ILog _logger = LogManager.GetLogger("SocialNetworkAnalyser");

        public static void LogError(Exception exception)
        {
            _logger.Error(exception.Message, exception);
        }
        public static void LogError(string message)
        {
            _logger.Error(message);
        }
    }
}
