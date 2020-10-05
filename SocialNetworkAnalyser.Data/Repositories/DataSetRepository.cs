using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class DataSetRepository : RepositoryBase, IDataSetRepository
    {
        public DataSetRepository(AppContext context) 
            : base(context)
        {
        }

        public DataSet Get(Guid id)
        {
            try
            {
                return Context.DataSets.AsNoTracking().FirstOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public List<DataSet> GetAll()
        {
            try
            {
                return Context.DataSets.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Add(DataSet dataSet)
        {
            try
            {
                Context.DataSets.Add(dataSet);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
