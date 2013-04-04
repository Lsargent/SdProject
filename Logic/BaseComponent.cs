using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class BaseComponent : IObjectState {
        
        public BaseComponent() {}

        public BaseComponent(OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Threads = new List<MessageThread>();
            Images = new List<Image>();
            OEntity = ownedEntity;
            
        }

        #region Backing Fields

        #endregion


        [Key]
        public int Id { get; set; }

        public virtual List<MessageThread> Threads { get; set; }

        public virtual List<Image> Images { get; set; }

        [Required]
        public virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }
    }
}