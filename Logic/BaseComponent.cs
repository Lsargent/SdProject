using System.Collections.Generic;

namespace Logic {
    public class BaseComponent {
        public int Id { get; set; }

        public virtual List<MessageThread> Threads { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual OwnedEntity OEntity { get; set; }
    }
}