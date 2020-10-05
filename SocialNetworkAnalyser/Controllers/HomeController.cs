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
                if (model.SourceFile.InputStream == null || model.SourceFile.InputStream.Length == 0)
                {
                    ModelState.AddModelError("SourceFile", "Error while uploading file. Please try again");
                    return PartialView(model);
                }

                var importResult = DataSetManager.ImportDataSet(model.SourceFile.InputStream, model.FileName);
                if (importResult.Success)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("SourceFile", importResult.ErrorMessage);
            }

            return PartialView(model);          
        }

        [HttpPost]
        public JsonResult ShowStatistics(Guid dataSetId)
        {
            var dataSet = DataSetManager.Get(dataSetId);
            int totalUsersCount = StatisticsManager.FriendsCountInDataSet(dataSetId);
            double averageFriendsCount = StatisticsManager.AverageFriendsCountForEachPerson(dataSetId);

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