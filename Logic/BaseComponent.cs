using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class BaseComponent : IObjectState {
        public int Id { get; set; }

        public virtual List<MessageThread> Threads { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}