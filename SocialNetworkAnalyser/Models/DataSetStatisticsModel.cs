using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetworkAnalyser.Models
{
    public class DataSetStatisticsModel
    {
        public string DataSetName { get; set; }
        public int TotalUsersCount { get; set; }
        public double AverageFriendCountForUser { get; set; }

        public bool Success { get; set; }
    }
}