using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class User : IObjectState, IEquatable<User> {
        
        public User() {}

        public User(string email, string userName, Entity entity, Address address = null) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Email = email;
            UserName = userName;
            Entity = entity;
            PrimaryAddress = address;
            ViewPolicy = ViewPolicy.Open;
        }

        #region Backing Fields
        private string _email;
        private string _userName;
        private Entity _entity;
        private Address _primaryAddress;
        private ViewPolicy _viewPolicy;

        #endregion

        public int Id { get; set; }

        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string Email {
            get { return _email; }
            set { _email = ChangeTracker.Set(this, Email, value); }
        }

        [MaxLength(100, ErrorMessage = "Username cannot be longer that 100 characters")]
        public string UserName {
            get { return _userName; }
            set { _userName = ChangeTracker.Set(this, UserName, value); }
        }

        public virtual ICollection<House> Houses { get; set; }

        public virtual Address PrimaryAddress {
            get { return _primaryAddress; }
            set { _primaryAddress = ChangeTracker.Set(this, PrimaryAddress, value); }
        }

        public virtual ICollection<Friendship> Friends { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<MessageThread> MessageThreads { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<UserOwnedEntity> UserOwnedEntities { get; set; }

        public virtual ICollection<OwnedEntityChange> OwnedEntityChanges { get; set; }

        public virtual Entity Entity {
            get { return _entity; }
            set { _entity = ChangeTracker.Set(this, Entity, value); }
        }

        public ViewPolicy ViewPolicy {
            get { return _viewPolicy; }
            set {
                if (TrackingEnabled && ObjectState == ObjectState.Unchanged && ViewPolicy != value) {
                    ObjectState = ObjectState.Modified;
                }
                _viewPolicy = value;
            }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public void AddHouse(House house) {
            ChangeTracker.AddToCollection(this, Houses, house);
        }

        public void AddFriendship(Friendship friend) {
            ChangeTracker.AddToCollection(this, Friends, friend);
        }

        public void AddImage(Image image) {
            ChangeTracker.AddToCollection(this, Images, image);
        }

        public void AddMessageThread(MessageThread thread) {
            ChangeTracker.AddToCollection(this, MessageThreads, thread);
        }

        public void AddMessage(Message message) {
            ChangeTracker.AddToCollection(this, Messages, message);
        }

        public void AddUserOwnedEntity(UserOwnedEntity entity) {
            ChangeTracker.AddToCollection(this, UserOwnedEntities, entity);
        }

        public void AddOwnedEntityChange(OwnedEntityChange entityChange) {
            ChangeTracker.AddToCollection(this, OwnedEntityChanges, entityChange);
        }

        public bool Equals(User other) {
            return Id == other.Id;
        }
    }
}

