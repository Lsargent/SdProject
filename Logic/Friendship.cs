using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class Friendship : IObjectState, IEquatable<Friendship> {
        
        public Friendship() {}

        public Friendship(User initiator, User reciever, OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Initiator = initiator;    
            Initiator.AddFriendship(this);         
            Reciever = reciever;
            Reciever.AddFriendship(this);
            Status = FriendshipStatus.Pending;
            OwnedEntity = ownedEntity;                 
        }

        #region Backing Fields
        private User _initiator;
        private User _reciever;
        private FriendshipStatus _status;
        private OwnedEntity _ownedEntity;
        #endregion

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Initiator {
            get { return _initiator; }
            set { _initiator = ChangeTracker.Set(this, Initiator, value); }
        }

        [Required]
        public virtual User Reciever {
            get { return _reciever; }
            set { _reciever = ChangeTracker.Set(this, Reciever, value); }
        }

        [Required]
        public FriendshipStatus Status {
            get { return _status; }
            set {
                if (TrackingEnabled && ObjectState == ObjectState.Unchanged && Status != value) {
                    ObjectState = ObjectState.Modified;
                }
                _status = value;
            }
        }

        [Required]
        public virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(Friendship other) {
            return Id == other.Id;
        }
    }
    public enum FriendshipStatus { 
        Confirmed,
        Pending,
        Blocked
    }
}