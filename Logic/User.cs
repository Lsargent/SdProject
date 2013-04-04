using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : IObjectState {
        public User() {}

        public User(string email, string userName, Entity entity, Address address = null) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Email = email;
            UserName = userName;
            Entity = entity;
            PrimaryAddress = address;            
        }

        public int Id { get; set; }

        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string UserName { get; set; }

        public virtual ICollection<House> Houses { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual ICollection<Friendship> Friends { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<MessageThread> MessageThreads { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<OwnedEntity> OwnedEntities { get; set; }

        public virtual ICollection<OwnedEntityChange> OwnedEntityChanges { get; set; }

        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }
    }
}

