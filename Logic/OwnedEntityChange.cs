using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Logic.Helpers;

namespace Logic {
    public class OwnedEntityChange : IObjectState, IEquatable<OwnedEntityChange> {
        
        public OwnedEntityChange() {}

        public OwnedEntityChange(HttpRequestBase request, User user) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            IpAddress = request.UserHostAddress;
            UserAgent = request.UserAgent;
            EditedOn = DateTime.Now;
            EditedbyUser = user;
            user.AddOwnedEntityChange(this);
        }

        #region Backing Fields
        private string _ipAddress;
        private string _userAgent;
        private DateTime _editedOn;
        private User _editedbyUser;
        private OwnedEntity _ownedEntity;
        #endregion

        [Key]
        public int Id { get; set; }

        [Required]
        public string IpAddress {
            get { return _ipAddress; }
            set { _ipAddress = ChangeTracker.Set(this, IpAddress, value); }
        }

        [Required]
        public string UserAgent {
            get { return _userAgent; }
            set { _userAgent = ChangeTracker.Set(this, UserAgent, value); }
        }

        [Required]
        public DateTime EditedOn {
            get { return _editedOn; }
            set { _editedOn = ChangeTracker.Set(this, EditedOn, value); }
        }

        public int EditedbyUserId { get; set; }

        [ForeignKey("EditedbyUserId")]
        public virtual User EditedbyUser {
            get { return _editedbyUser; }
            set { _editedbyUser = ChangeTracker.Set(this, EditedbyUser, value); }
        }

        public int OwnedEntityId { get; set; }

        [ForeignKey("OwnedEntityId")]
        public virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(OwnedEntityChange other) {
            return Id == other.Id;
        }
    }
}
