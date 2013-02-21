using System.Collections.Generic;

namespace Logic {
    public class BaseComponent : OwnedEntity {
        public virtual List<MessageThread> Threads {
            get;
            set;
        }

        public override int Id {
            get;
            set;
        }

        public virtual List<Image> Images {
            get;
            set;
        }

    }
}

