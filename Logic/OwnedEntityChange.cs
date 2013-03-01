using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Logic {
    public class OwnedEntityChange : IObjectState {
        public OwnedEntityChange() {
        }

        public OwnedEntityChange(OwnedEntityChangeParams changeParams) {
            IpAddress = changeParams.Request.UserHostAddress;
            UserAgent = changeParams.Request.UserAgent;
            EditedOn = DateTime.Now;
            EditedbyUser = changeParams.User;
        }

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public DateTime EditedOn { get; set; }

        public virtual User EditedbyUser { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }

    public class OwnedEntityChangeParams {
        public OwnedEntityChangeParams(HttpRequestBase request, User user) {
            Request = request;
            User = user;
        }

        public HttpRequestBase Request { get; set; }

        public User User { get; set; }
    }
}
