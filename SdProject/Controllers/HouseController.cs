using System;
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
                string name = WebSecurity.CurrentUserName;
                using (var userRepo = new UserRepository())
                {
                    user = userRepo.GetUserWithIncludes(WebSecurity.CurrentUserId, u => u.Houses, u => u.UserOwnedEntities, u => u.OwnedEntityChanges);
                }
                user.TrackingEnabled = true;
                var newHouse = new House(   new Address(house.StreetAddress, "", house.City, house.State, house.ZipCode.ToString(), 
                                                new OwnedEntity(user, ViewPolicy.Open, 
                                                    new OwnedEntityChange(Request, user))), 
                                            house.Style,
                                            house.FloorSpace,
                                            house.RoomCount,
                                            house.StoryCount,
                                            house.Bedrooms,
                                            house.Bathrooms,
                                            house.Extras,
                                            new BaseComponent( 
                                                new OwnedEntity(user, ViewPolicy.Open, 
                                                    new OwnedEntityChange(Request,  user))),
                                            house.HeatingType);

                using(var houseRepo = new HouseRepository()){
                    houseRepo.InsertOrUpdate(newHouse);
                }
                return RedirectToAction("ProfileDisplay", "Account", new { username = name });
            }
            return View("EnterInfo", house);
        }

        [HttpGet]
        public ActionResult Edit(int houseId) {
            //Finds a house using the house repo and then returns a form with the elements of the house in the form.
            //The EnterInfo model/view can be reused, but a house id property needs to be added to both the model and the form.
            //Renaming EnterInfo to a more descriptive name would be nice.
                EnterInfo houseModel;
                using (var houserepo = new HouseRepository())
                {
                    houseModel = new EnterInfo(houserepo.Get<House>( h => h.Id == houseId, h => h.Address));
                }
                
                return View(houseModel);
        }

        [HttpPost]
        public ActionResult Edit(EnterInfo houseModel) {
            House toUpdate;
            //Take in the form input
            //Get a house from the house respository and update the properties based on input
            //Save the updated house using the repository
            //Be sure to use ModelState.IsValid and to validate whether or not the current user has permission to edit the house
            using (var houserepo = new HouseRepository())
            {
                toUpdate =  houserepo.Get<House>(h => h.Id == houseModel.houseId, h => h.Address);
            }
            if (ModelState.IsValid)
            {
                toUpdate.TrackingEnabled = true;
                toUpdate.Address.TrackingEnabled = true;
                toUpdate.RoomCount = houseModel.RoomCount;
                toUpdate.Address.StreetAddress = houseModel.StreetAddress;
                toUpdate.Address.ZipCode = Convert.ToString(houseModel.ZipCode);
                toUpdate.Address.City = houseModel.City;
                toUpdate.Address.State = houseModel.State;
                toUpdate.Style = houseModel.Style;
                toUpdate.Extras = houseModel.Extras;
                toUpdate.FloorSpace = houseModel.FloorSpace;
                toUpdate.Bathrooms = houseModel.Bathrooms;
                toUpdate.Bedrooms = houseModel.Bedrooms;
                toUpdate.HeatingType = houseModel.HeatingType;

                using (var houseRepo = new HouseRepository())
                {
                    houseRepo.InsertOrUpdate(toUpdate);
                }
                return RedirectToAction("ProfileDisplay", "Account", new { userName = WebSecurity.CurrentUserName});
            }
            return View(houseModel);
        }

        public ActionResult Display(int houseId)
        {
            HouseDisplayModel house;
            using(var houserepo = new HouseRepository())
            {
                house = new HouseDisplayModel(houserepo.Get<House>(h => h.Id == houseId, h => h.Address, h => h.BaseComponent.MessageThreads));
            }
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_House", house) : View("_House", house);
        }

        //public ActionResult EditHouse(int houseId)
        //{
        //    EnterInfo houseModel;
        //    using (var houserepo = new HouseRepository())
        //    {
        //        houseModel = new EnterInfo(houserepo.GetHouse(houseId));
        //    }
        //    return View();
        //}

        //public ActionResult EditInfo(EnterInfo house)
        //{
            
        //}

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

        

        
    }
}
