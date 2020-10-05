using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Business.Models
{
    public class ImportDataSetResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ImportDataSetResult(bool success)
        {
            Success = success;
        }
        public ImportDataSetResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
