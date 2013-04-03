using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class Message : IObjectState {
        
        public Message() {}

        public Message(string subject, string messageBody, OwnedEntity ownedEntity) {
            Subject = subject;
            MessageBody = messageBody;
            OwnedEntity = ownedEntity;
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        #region Backing Fields

        private string _messageBody;
        private string _subject;

        #endregion

        [Required, MinLength(1)]
        public string MessageBody {
            get  { return _messageBody; }
            set { _messageBody = ChangeTracker.SetChange(this, MessageBody, value); }
        }

        [Required, MinLength(1)]
        public string Subject {
            get { return _subject; }
            set { _subject = ChangeTracker.SetChange(this, Subject, value); }
        }

        public virtual OwnedEntity OwnedEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}