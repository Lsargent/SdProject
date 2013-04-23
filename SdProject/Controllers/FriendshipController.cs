using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using SdProject.Models.FriendshipModels;

namespace SdProject.Controllers
{
    [Authorize]
    public class FriendshipController : HfController
    {
        public ActionResult Create() {
            ICollection<User> users;
            SetCurrentUserWithIncludes(u => u.FriendReceptions, 
                                       u => u.FriendInitiations);
            using (var userRepo = new UserRepository()) {
                users = userRepo.GetAllWithIncludes<User>(u => !u.FriendInitiations.Any(f => f.RecieverId == CurrentUser.Id) && !u.FriendReceptions.Any(f => f.InitiatorId == CurrentUser.Id)).ToList();            
            }
            users.Remove(CurrentUser);
            var model = new CreateFriendshipModel(users, CurrentUser);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(FriendshipModel friendship) {
            if(ModelState.IsValid) {
                SetCurrentUserWithIncludes(u => u.FriendReceptions,
                                           u => u.FriendInitiations, 
                                           u => u.OwnedEntityChanges,
                                           u => u.UserOwnedEntities);
                User reciever;
                using (var userRepo = new UserRepository()) {
                    reciever = userRepo.Get<User>(u => u.Id == friendship.RecieverId, 
                                                    u => u.OwnedEntityChanges,
                                                    u => u.UserOwnedEntities,
                                                    u => u.FriendInitiations.Select(f => f.OwnedEntity),
                                                    u => u.FriendReceptions.Select(f => f.OwnedEntity));
                }
                if (friendship.InitiatorId == CurrentUser.Id && !CurrentUser.Friends.Any(f => f.InitiatorId == reciever.Id || f.RecieverId == reciever.Id)) {   
                    CurrentUser.TrackingEnabled = true;
                    reciever.TrackingEnabled = true;
                    var ownedEntity = new OwnedEntity(CurrentUser, ViewPolicy.Open,
                                                        new OwnedEntityChange(Request, CurrentUser));
                    ownedEntity.AddOwner(reciever);
                    var newFriendship = new Friendship(CurrentUser, reciever, ownedEntity);
  
                    OperationStatus operationStatus;
                    using (var friendshipRepo = new FriendshipRepository()) {
                        operationStatus = friendshipRepo.InsertOrUpdate(newFriendship);
                    }
                    if (operationStatus.WasSuccessful) {
                        return RedirectToAction("ProfileDisplay", "Account", new { userName = CurrentUser.UserName });
                    }                 
                }
            }
            return Create();      
        }
    }
}
