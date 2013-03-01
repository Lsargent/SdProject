using System;
using System.Net;
using System.Web;

namespace Logic {
    public class EntityChange {
        public EntityChange() {}

        public EntityChange(EntityChangeParams changeParams) {
            Editedby = changeParams.Request.UserHostName;
            IpAddress = changeParams.Request.UserHostAddress;
            UserAgent = changeParams.Request.UserAgent;
            EditedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Editedby { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public DateTime EditedOn { get; set; }

        public virtual Entity Entity { get; set; }
    }

    public class EntityChangeParams {
        public EntityChangeParams(HttpRequestBase request) {
            Request = request;
        }

        public HttpRequestBase Request { get; set; }
    }
}