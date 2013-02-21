using System;

namespace Logic {
    public class EntityChange {
        public virtual string Editedby {
            get;
            set;
        }

        public virtual DateTime EditedOn {
            get;
            set;
        }

        public virtual int Id {
            get;
            set;
        }

        public virtual Entity Entity {
            get;
            set;
        }

        public virtual string IpAddress {
            get;
            set;
        }

        public virtual string UserAgent {
            get;
            set;
        }

    }
}

