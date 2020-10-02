using SocialNetworkAnalyser.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetworkAnalyser.CustomControllers
{
    public class BaseController : Controller
    {
        private DataSetManager _dataSetManager;
        protected DataSetManager DataSetManager
        {
            get
            {
                if (_dataSetManager == null)
                    _dataSetManager = new DataSetManager();

                return _dataSetManager;
            }
        }

        private StatisticsManager _statisticsManager;
        protected StatisticsManager StatisticsManager
        {
            get
            {
                if (_statisticsManager == null)
                    _statisticsManager = new StatisticsManager();

                return _statisticsManager;

            }
        }
    }
}