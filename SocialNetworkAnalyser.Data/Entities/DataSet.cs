using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Entities
{
    public class DataSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public static DataSet Create(string name)
        {
            return new DataSet()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Name = name
            };
        }
    }
}
