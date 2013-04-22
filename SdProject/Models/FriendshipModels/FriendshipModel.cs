using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;
using Logic.Helpers;
using SdProject.Models.AccountModels;

namespace SdProject.Models.FriendshipModels {
    public class FriendshipModel {
        public FriendshipModel() {
            
        }

        public FriendshipModel(Friendship friendship, User currentUser) {
            InitiatorId = friendship.Initiator.Id;
            Initiator = new ProfilePreviewModel(friendship.Initiator);
            RecieverId = friendship.Reciever.Id;
            Reciever = new ProfilePreviewModel(friendship.Reciever);
            CurrentUserId = currentUser.Id;
            Status = friendship.Status;
            HasViewPermission = PermissionHelper.HasViewPermission(friendship.OwnedEntity, currentUser);
            HasEditPermission = PermissionHelper.HasEditPermission(friendship.OwnedEntity, currentUser);
        }

        public int FriendshipId { get; set; }

        public int InitiatorId { get; set; }

        public int RecieverId { get; set; }

        public int CurrentUserId { get; set; }

        public ProfilePreviewModel Initiator { get; set; }

        public ProfilePreviewModel Reciever { get; set; }

        public FriendshipStatus Status { get; set; }

        public bool HasViewPermission { get; set; }

        public bool HasEditPermission { get; set; }
    }
}