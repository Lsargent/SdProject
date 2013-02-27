using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic {
    public class OwnedEntity : Entity {
        public OwnedEntity(){}

        public OwnedEntity(OwnedEntityParams oEParams) : base(oEParams) {
            OwnedHistory = new List<OwnedEntityChange>() { new OwnedEntityChange(oEParams.OwnedChangeParams) };
            Owners = new List<User> {oEParams.User};
        }

        public virtual List<User> Owners { get; set; }

        public virtual ViewPolicy ViewPolicy { get; set; }

        public virtual List<OwnedEntityChange> OwnedHistory { get; set; }
    }

    public class OwnedEntityParams : EntityParams {
        public OwnedEntityParams(HttpRequestBase request, User user) : base(request) {
            OwnedChangeParams = new OwnedEntityChangeParams(request, user);
            User = user;
        }

        public OwnedEntityChangeParams OwnedChangeParams { get; set; }

        public User User { get; set; }
    }
}