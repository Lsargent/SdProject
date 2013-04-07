using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class BaseComponent : IObjectState, IEquatable<BaseComponent> {
        
        public BaseComponent() {}

        public BaseComponent(OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            MessageThreads = new List<MessageThread>();
            Images = new List<Image>();
            OEntity = ownedEntity;
            
        }

        #region Backing Fields
        private OwnedEntity _oEntity;
        #endregion


        [Key]
        public int Id { get; set; }

        public virtual ICollection<MessageThread> MessageThreads { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [Required]
        public virtual OwnedEntity OEntity {
            get { return _oEntity; }
            set { _oEntity = ChangeTracker.Set(this, OEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public void AddMessageThread(MessageThread thread) {
            ChangeTracker.AddToCollection(this, MessageThreads, thread);
        }

        public void AddImage(Image image) {
            ChangeTracker.AddToCollection(this, Images, image);
        }

        public bool Equals(BaseComponent other) {
            return Id == other.Id;
        }
    }
}