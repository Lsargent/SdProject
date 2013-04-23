using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helpers {
    public static class PermissionHelper {
        public static bool HasEditPermission(OwnedEntity entity, User user) {
             return entity.UserOwnedEntities.Any(uoe => uoe.User.Equals(user));
        }
        public static bool HasViewPermission(OwnedEntity entity, User user) {
            var viewPolicy = entity.ViewPolicy;
            if (viewPolicy == ViewPolicy.Open) {
                return true;
            }
            if (HasEditPermission(entity, user)) {
                return true;
            }
            if(viewPolicy == ViewPolicy.Closed) {
                return false;
            }
            var hasPermission = false;
            foreach (var uoe in entity.UserOwnedEntities) {
                hasPermission =  uoe.User.Friends.Any(
                                    friend =>
                                    (friend.Initiator.Equals(user) || friend.Reciever.Equals(user)) &&
                                    friend.Status == FriendshipStatus.Confirmed);
                if (hasPermission) {
                    break;
                }
            }
            return hasPermission;
        }

        public static bool HasProfileViewPermission(User profileUser, User requestingUser) {
            var viewPolicy = profileUser.ViewPolicy;
            if (viewPolicy == ViewPolicy.Open) {
                return true;
            }
            if (profileUser.Equals(requestingUser)) {
                return true;
            }
            if (viewPolicy == ViewPolicy.Closed) {
                return false;
            }
            var hasPermission = profileUser.Friends.Any(
                                   friend =>
                                      (friend.Initiator.Equals(requestingUser) || friend.Reciever.Equals(requestingUser)) &&
                                      friend.Status == FriendshipStatus.Confirmed);
            return hasPermission;
        }

        public static bool HasProfileEditPermission(User profileUser, User requestingUser) {
            return profileUser.Equals(requestingUser);
        }
    }
}
