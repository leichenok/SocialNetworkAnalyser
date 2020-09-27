using SocialNetworkAnalyser.Data.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetworkAnalyser.Data.Repositories.Interfaces
{
    public interface IDataSetRepository
    {
        DataSet Get(Guid id);
        List<DataSet> GetAll();
        void Add(DataSet dataSet);
    }
}
