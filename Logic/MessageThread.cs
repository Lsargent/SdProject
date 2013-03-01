using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class MessageThread : IObjectState {
        public int Id { get; set; }

        public string Subject { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual User Author { get; set; }

        public virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}