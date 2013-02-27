using System.Web;

namespace Logic {
    public class OwnedEntityChange : EntityChange {
        public OwnedEntityChange() {}

        public OwnedEntityChange(OwnedEntityChangeParams changeParams) : base(changeParams) {
            EditedbyUser = changeParams.User;
        }

        public virtual User EditedbyUser { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }
    }

    public class OwnedEntityChangeParams : EntityChangeParams{
        public OwnedEntityChangeParams(HttpRequestBase request, User user) : base(request) {
            User = user;
        }

        public User User { get; set; }
    }
}
