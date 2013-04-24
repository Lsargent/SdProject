using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataAccess.Repositories;
using WebMatrix.WebData;
using Logic;

namespace SdProject.Controllers
{
    [Authorize]
    public class ImageController : HfController
    {
        //UploadImage needs to be moved to the image controller
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(SdProject.Models.ImageModels.UploadImageModel fileModel)
        {                 
            if (ModelState.IsValid)
            {
                SetCurrentUserWithIncludes(u => u.UserOwnedEntities, u => u.OwnedEntityChanges);
                var path = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + CurrentUser.Id + "\\");
                if (!path.Exists && path.Directory != null) {
                    path.Directory.Create();
                }
                if (fileModel != null && fileModel.File != null) {
                    var fileName = Path.GetFileName(fileModel.File.FileName);
                    fileModel.File.SaveAs(path + fileName);
                    CurrentUser.TrackingEnabled = true;
                    var image = new Logic.Image("../Images/" + CurrentUser.Id + "/" + fileName, 
                                                new OwnedEntity(CurrentUser,
                                                                ViewPolicy.Open, 
                                                                new OwnedEntityChange(Request,CurrentUser)));
                    OperationStatus operationStatus;
                    using (var imageRepo = new ImageRepository()) {
                        operationStatus = imageRepo.InsertOrUpdate(image);
                    }
                    
                    if (operationStatus.WasSuccessful) {
                        return RedirectToAction("ProfileDisplay", "Account", new { username = CurrentUser.UserName });
                    }                 
                }           
            }
            return View(fileModel);
        }
    }
}
