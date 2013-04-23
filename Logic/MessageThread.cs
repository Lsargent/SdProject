using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class MessageThread : IObjectState, IEquatable<MessageThread> {
        
        public MessageThread() {}

        public MessageThread(string subject, Message message, User author, BaseComponent baseComponent, OwnedEntity ownedEntity) {           
            Subject = subject;
            Messages = new List<Message> { message };
            Author = author;
            Author.AddMessageThread(this);
            BaseComponent = baseComponent;
            BaseComponent.AddMessageThread(this);
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        #region Backing Fields
        private string _subject;
        private User _author;
        private BaseComponent _baseComponent;
        private OwnedEntity _ownedEntity;
        #endregion

        public int Id { get; set; }

        public string Subject {
            get { return _subject; }
            set { _subject = ChangeTracker.Set(this, Subject, value); }
        }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual User Author {
            get { return _author; }
            set { _author = ChangeTracker.Set(this, Author, value); ; }
        }

        public virtual BaseComponent BaseComponent {
            get { return _baseComponent; }
            set { _baseComponent = ChangeTracker.Set(this, BaseComponent, value); }
        }

        public virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(MessageThread other) {
            return Id == other.Id;
        }
    }
}