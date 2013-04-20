using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SdProject.Controllers
{
    public class ImageController : Controller
    {
        //UploadImage needs to be moved to the image controller
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(SdProject.Models.ImageModels.UploadImageModel fileModel)
        {
            string path = @"C:\Users\kholiway\Documents\GitHub\SdProject\SdProject\App_Data\";
            int userid = WebSecurity.CurrentUserId;
            

            if (ModelState.IsValid)
            {
                if (fileModel != null && fileModel.File != null)
                    fileModel.File.SaveAs(path + userid + "\\1.jpeg");

                return RedirectToAction("ProfileDisplay", "Account", new { username = "n2" });
            }

            return View();
        }
    }
}
