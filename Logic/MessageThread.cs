using System.Collections.Generic;

namespace Logic {
    public class MessageThread : OwnedEntity {
        public virtual string Subject { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual User Author { get; set; }
    }
}