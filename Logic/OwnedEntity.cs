using System.Collections.Generic;

namespace Logic {
    public class OwnedEntity : Entity {
        public virtual List<User> Owners {
            get;
            set;
        }

        public virtual ViewPolicy ViewPolicy {
            get;
            set;
        }

        public virtual List<OwnedEntityChange> History {
            get;
            set;
        }

        public override int Id {
            get;
            set;
        }

    }
}

