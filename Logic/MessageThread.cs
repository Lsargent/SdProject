using System.Collections.Generic;

namespace Logic {
    public class MessageThread {
        public int Id { get; set; }

        public string Subject { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual User Author { get; set; }

        public virtual OwnedEntity OEntity { get; set; }
    }
}