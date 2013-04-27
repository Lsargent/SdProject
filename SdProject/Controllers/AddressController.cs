using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using Logic.Helpers;
using SdProject.Models.AddressModels;
using WebMatrix.WebData;

namespace SdProject.Controllers
{
    [Authorize]
    public class AddressController : HfController
    {
        public ActionResult Display(int addressId) {
            Address address;
            using (var addressRepo = new AddressRepository()) {
                address = addressRepo.Get<Address>(a => a.Id == addressId, a => a.OwnedEntity.UserOwnedEntities);
            }
            var model = new AddressModel(address, CurrentUser);
            return View("Display", model);
        }

        [HttpGet]
        public ActionResult Create() {
            var model = new AddressModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(AddressModel address) {
            if (ModelState.IsValid) {
                SetCurrentUserWithIncludes(u => u.UserOwnedEntities, u => u.OwnedEntityChanges);
                CurrentUser.TrackingEnabled = true;
                var newAddress = new Address(address.StreetAddress,
                                             address.StreetAddress2, 
                                             address.City, 
                                             address.State, 
                                             address.ZipCode,
                                             new OwnedEntity(CurrentUser, 
                                                             ViewPolicy.Open,
                                                             new OwnedEntityChange(Request, 
                                                                                   CurrentUser)));
                OperationStatus operationStatus;
                using (var addressRepo = new AddressRepository()) {
                    operationStatus = addressRepo.InsertOrUpdate(newAddress);
                }
                if (operationStatus.WasSuccessful) {
                    return RedirectToAction("ProfileDisplay", "Account", new { userName = WebSecurity.CurrentUserName });
                }
            }
            return View("Create", address);
        }

        [HttpGet]
        public ActionResult Edit(int addressId) {
            Address address;
            using (var addressRepo = new AddressRepository()) {
                address = addressRepo.Get<Address>(a => a.Id == addressId, a => a.OwnedEntity.UserOwnedEntities.Select(uoe => uoe.User));
            }
            if (address != null) {
                var model = new AddressModel(address, CurrentUser);
                if (model.HasEditPermisssion) {
                    return View("Edit", model);
                }
                ViewBag.Name = "Address-" + addressId;
                return View("NoEditPermission");
            }
            return RedirectToAction("ProfileDisplay", "Account", new { userName = WebSecurity.CurrentUserName });
        }

        [HttpPost]
        public ActionResult Edit(AddressModel address) {
            if (ModelState.IsValid) {
                Address addressToUpdate;
                using (var addressRepo = new AddressRepository()) {
                    addressToUpdate = addressRepo.Get<Address>(a => a.Id == address.AddressId, a => a.OwnedEntity.UserOwnedEntities.Select(uoe => uoe.User));
                }
                if (addressToUpdate != null && PermissionHelper.HasEditPermission(addressToUpdate.OwnedEntity, CurrentUser)) {
                    addressToUpdate.TrackingEnabled = true;
                    addressToUpdate.StreetAddress = address.StreetAddress;
                    addressToUpdate.StreetAddress2 = address.StreetAddress2;
                    addressToUpdate.City = address.City;
                    addressToUpdate.State = address.State;
                    addressToUpdate.ZipCode = address.ZipCode;

                    OperationStatus<Address> operationStatus;
                    using (var addressRepo = new AddressRepository()) {
                        operationStatus = addressRepo.InsertOrUpdate(addressToUpdate);
                    }

                    if (operationStatus.WasSuccessful) {
                        return RedirectToAction("ProfileDisplay", "Account", new { userName = WebSecurity.CurrentUserName });
                    }
                }              
            }
            return View("Edit", address);
        }
    }
}
