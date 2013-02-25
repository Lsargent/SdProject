using System.Collections.Generic;

namespace Logic {
    public class Entity {
        public virtual int Id { get; set; }

        public virtual EntityChange LastEdited { get; set; }

        public virtual EntityChange Created { get; set; }

        public virtual List<EntityChange> History { get; set; }     
    }
}