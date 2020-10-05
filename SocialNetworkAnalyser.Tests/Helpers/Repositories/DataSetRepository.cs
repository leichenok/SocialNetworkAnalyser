using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Helpers.Repositories
{
    public class DataSetRepository : IDataSetRepository
    {
        public List<DataSet> DataSets = new List<DataSet>();

        public void Add(DataSet dataSet)
        {
            DataSets.Add(dataSet);
        }

        public DataSet Get(Guid id)
        {
            return DataSets.FirstOrDefault(d => d.Id == id);
        }

        public List<DataSet> GetAll()
        {
            return DataSets;
        }
    }
}
