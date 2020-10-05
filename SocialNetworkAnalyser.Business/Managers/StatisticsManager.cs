using SocialNetworkAnalyser.Business.Logging;
using SocialNetworkAnalyser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Business.Managers
{
    public class StatisticsManager : ManagerBase
    {
        public int FriendsCountInDataSet(Guid dataSetId)
        {
            try
            {
                using(var repository = NewRepositoryFactory())
                {
                    return repository.Friends.Count(dataSetId);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return -1;
            }
        }
        public double AverageFriendsCountForEachPerson(Guid dataSetId)
        {
            try
            {
                using(var repository = NewRepositoryFactory())
                {
                    var result = repository.Friendships.GetAverageFriendsCountForEachPerson(dataSetId);
                    return Math.Round(result, 2);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return -1;
            }
        }
    }
}
