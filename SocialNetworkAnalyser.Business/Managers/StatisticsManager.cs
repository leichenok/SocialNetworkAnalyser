using SocialNetworkAnalyser.Business.Logging;
using SocialNetworkAnalyser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Business.Managers
{
    public class StatisticsManager
    {
        public int UsersCountInDataSet(Guid dataSetId)
        {
            try
            {
                using(var repository = new UnitOfWorkFactory())
                {
                    return repository.Users.Count(dataSetId);
                }
            } catch(Exception ex)
            {
                Logger.LogError(ex);
                return -1;
            }
        }

        public double AverageFriendsCountForEachUser(Guid dataSetId)
        {
            try
            {
                using(var repository = new UnitOfWorkFactory())
                {
                    var result = repository.Friendships.GetAverageFriendsCountForEachUser(dataSetId);
                    return Math.Round(result, 2);
                }
            } catch(Exception ex)
            {
                Logger.LogError(ex);
                return -1;
            }
        }
    }
}
