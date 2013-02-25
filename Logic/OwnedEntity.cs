using System.Collections.Generic;

namespace Logic {
    public class OwnedEntity : Entity {
        public virtual List<User> Owners { get; set; }

        public virtual ViewPolicy ViewPolicy { get; set; }

        public new virtual List<OwnedEntityChange> History { get; set; }
    }
}