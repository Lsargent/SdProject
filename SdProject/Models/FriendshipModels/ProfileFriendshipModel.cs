using Logic;
using Logic.Helpers;
using SdProject.Models.AccountModels;

namespace SdProject.Models.FriendshipModels {
    public class ProfileFriendshipModel {
        public ProfileFriendshipModel() {}

        public ProfileFriendshipModel(Friendship friendship, User profileUser, User currentUser) {
            var userToDisplay = friendship.Initiator.Equals(profileUser) ? friendship.Reciever : friendship.Initiator;
            Friend = new ProfilePreviewModel(userToDisplay);
            Status = friendship.Status;
            HasViewPermission = PermissionHelper.HasViewPermission(friendship.OwnedEntity, currentUser);
            HasEditPermission = PermissionHelper.HasEditPermission(friendship.OwnedEntity, currentUser);
        }

        public ProfilePreviewModel Friend { get; set; }

        public FriendshipStatus Status { get; set; }

        public bool HasViewPermission { get; set; }

        public bool HasEditPermission { get; set; }
    }
}