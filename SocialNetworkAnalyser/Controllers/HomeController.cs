using SocialNetworkAnalyser.Business.Managers;
using SocialNetworkAnalyser.CustomControllers;
using SocialNetworkAnalyser.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SocialNetworkAnalyser.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var dataSets = DataSetManager.GetAll();       
            return View(dataSets);
        }

        public ActionResult LoadFile()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult LoadFile(LoadFileModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SourceFile.InputStream == null)
                {
                    ModelState.AddModelError("SourceFile", "error while uploading file. Please try again");
                    return PartialView(model);
                }

                bool success = DataSetManager
.ImportDataSet(model.SourceFile.InputStream, model.FileName);
                if (success)
                    return RedirectToAction("Index");
            }

            return PartialView(model);          
        }

        [HttpPost]
        public JsonResult ShowStatistics(Guid dataSetId)
        {
            var dataSet = DataSetManager.GetAll().FirstOrDefault(d => d.Id == dataSetId);
            int totalUsersCount = StatisticsManager.UsersCountInDataSet(dataSetId);
            double averageFriendsCount = StatisticsManager.AverageFriendsCountForEachUser(dataSetId);

            var model = new DataSetStatisticsModel()
            {
                DataSetName = dataSet.Name,
                TotalUsersCount = totalUsersCount,
                AverageFriendCountForUser = averageFriendsCount,
                Success = (totalUsersCount != -1 && averageFriendsCount != -1)
            };

            return Json(model);
        }

    }
}