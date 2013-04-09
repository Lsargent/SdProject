using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helpers {
    public static class PermissionHelper {
        public static bool HasEditPermission(OwnedEntity entity, User user) {
             return entity.Owners.Any(u => u.Equals(user));
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
            foreach (var owner in entity.Owners) {
                hasPermission = hasPermission ||
                                owner.Friends.Any(
                                    friend =>
                                    (friend.Initiator.Equals(user) || friend.Reciever.Equals(user)) &&
                                    friend.Status == FriendshipStatus.Confirmed);
            }
            return hasPermission;
        }
    }
}
