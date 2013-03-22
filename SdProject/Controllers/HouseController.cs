using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using DataAccess.Repositories;
using WebMatrix.WebData;
using SdProject.Filters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SdProject.Models;

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
        public ActionResult EnterInfo(SdProject.Models.HouseDisplayModel.EnterInfo house)
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
                var newHouse = new House(   house.streetAddress,
                                            house.city,
                                            house.zipCode,
                                            house.style,
                                            house.floorSpace,
                                            house.roomCount,
                                            house.storyCount,
                                            house.bedrooms,
                                            house.bathrooms,
                                            house.extras,
                                            new BaseComponent( new OwnedEntity(user, new OwnedEntityChange(Request, user))),
                                            house.heatingType);
                Houses.Add(newHouse);
                user.ObjectState = ObjectState.Modified;
                using(var houseRepo = new HouseRepository()){
                    houseRepo.InsertOrUpdate(newHouse);
                }
                return RedirectToAction("PageView", "Account");
            }
            return View("EnterInfo", house);
        }

        public ActionResult UploadImage()
        {
            return View();
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
        
    }
}
