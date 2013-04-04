using System.Collections.Generic;
using System.Web.Mvc;
using Logic;
using DataAccess.Repositories;
using SdProject.Models.HouseModels;
using WebMatrix.WebData;
using System.Web;
using System.Linq;

namespace SdProject.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        //
        // GET: /House/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult EnterInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterInfo(EnterInfo house)
        {
            if (ModelState.IsValid)
            {
                User user;
                List<House> Houses;
                using (var userRepo = new UserRepository())
                {
                    user = userRepo.GetUser(WebSecurity.CurrentUserId);
                    Houses = user.Houses;
                }
                var newHouse = new House(   house.StreetAddress,
                                            house.City,
                                            house.ZipCode,
                                            house.Style,
                                            house.FloorSpace,
                                            house.RoomCount,
                                            house.StoryCount,
                                            house.Bedrooms,
                                            house.Bathrooms,
                                            house.Extras,
                                            new BaseComponent( new OwnedEntity(user, ViewPolicy.Open, new OwnedEntityChange(Request,  user))),
                                            house.HeatingType);
                Houses.Add(newHouse);
                user.ObjectState = ObjectState.Modified;
                using(var houseRepo = new HouseRepository()){
                    houseRepo.InsertOrUpdate(newHouse);
                }
                return RedirectToAction("PageView", "Account");
            }
            return View("EnterInfo", house);
        }

        public ActionResult House(int houseid)
        {
            HouseDisplayModel house;
            using(var houserepo = new HouseRepository())
            {
                house = new HouseDisplayModel(houserepo.GetHouse(houseid));
            }
            return View("_House", house);
        }

        //[HttpPost]
        //public ActionResult UploadImage(HttpPostedFileBase photo)
        //{
        //    if (photo != null)
        //    {
        //        string path = @"D:\Temp\";

        //        if (photo.ContentLength > 10240)
        //        {
        //            ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
        //            return View();
        //        }

        //        var supportedTypes = new[] { "jpg", "jpeg", "png" };

        //        var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

        //        if (!supportedTypes.Contains(fileExt))
        //        {
        //            ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //            return View();
        //        }

        //        photo.SaveAs(path + photo.FileName);
        //    }

        //    return RedirectToAction("PageView", "Account");
        //}

        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(UploadImageModel fileModel)
        {
            string path = @"Desktop";

            if (ModelState.IsValid)
            {
                if (fileModel != null && fileModel.File != null)
                    fileModel.File.SaveAs(path + fileModel.File.FileName);

                return RedirectToAction("PageView", "Account");
            }

            return View();
        }

        
    }
}
