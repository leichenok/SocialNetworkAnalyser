using SocialNetworkAnalyser.Business.Managers;
using SocialNetworkAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetworkAnalyser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("LoadFile");
        }

        [HttpPost]
        public ActionResult LoadFile(HttpPostedFileBase file)
        {
            var manager = new DataSetManager();
            bool result = manager.ImportDataSet(file.InputStream);

            return Content(result ? "Success" : "Failed");
        }
    }
}