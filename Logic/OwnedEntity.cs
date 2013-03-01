using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class OwnedEntity : IObjectState {
        public OwnedEntity(){}

        public OwnedEntity(OwnedEntityParams oEParams) {
            OwnedHistory = new List<OwnedEntityChange>() { new OwnedEntityChange(oEParams.OwnedChangeParams) };
            Owners = new List<User> { oEParams.User };
        }
        public int Id { get; set; }

        public virtual List<User> Owners { get; set; }

        public virtual ViewPolicy ViewPolicy { get; set; }

        public virtual List<OwnedEntityChange> OwnedHistory { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }

    public class OwnedEntityParams {
        public OwnedEntityParams(HttpRequestBase request, User user) {
            OwnedChangeParams = new OwnedEntityChangeParams(request, user);
            User = user;
        }

        public OwnedEntityChangeParams OwnedChangeParams { get; set; }

        public User User { get; set; }
    }
}