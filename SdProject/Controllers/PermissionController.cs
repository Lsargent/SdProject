using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using Logic.Helpers;
using SdProject.Models;

namespace SdProject.Controllers
{
    public class PermissionController : HfController
    {
        public ActionResult Edit(int ownedEntityId) {
            OwnedEntity ownedEntity;
            using (var ownedEntityRepo = new OwnedEntityRepository()) {
                ownedEntity = ownedEntityRepo.Get<OwnedEntity>(oe => oe.Id == ownedEntityId, oe => oe.UserOwnedEntities.Select(uoe => uoe.User));
            }
            var model = new PermissionModel(ownedEntity, CurrentUser);

            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_EditPermission", model) : View("EditPermission", model); 
        }

        [HttpPost]
        public ActionResult Edit(PermissionModel model) {
            if (ModelState.IsValid) {
                OwnedEntity ownedEntity;
                using (var ownedEntityRepo = new OwnedEntityRepository()) {
                    ownedEntity = ownedEntityRepo.Get<OwnedEntity>(oe => oe.Id == model.OwnedEntityId, oe => oe.UserOwnedEntities.Select(uoe => uoe.User));
                }
                if (PermissionHelper.HasEditPermission(ownedEntity, CurrentUser)) {
                    ownedEntity.ViewPolicy = model.Policy;
                    OperationStatus operationStatus;
                    using (var ownedEntityRepo = new OwnedEntityRepository()) {
                        operationStatus = ownedEntityRepo.InsertOrUpdate(ownedEntity);
                    }
                    if (operationStatus.WasSuccessful) {
                        var updatedModel = new PermissionModel(ownedEntity, CurrentUser);
                        return Request.IsAjaxRequest() ? (ActionResult) PartialView("_PermissionDisplay", updatedModel) : View("PermissionDisplay", updatedModel);
                    }
                }
            }
            throw new NotImplementedException();
        }

        public ActionResult Display(int ownedEntityId) {
            throw new NotImplementedException();
        } 
    }
}
