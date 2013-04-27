using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class Image : IObjectState {

        public Image() {}

        public Image(string url, OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Url = url;
            OwnedEntityId = ownedEntity.Id;
            OwnedEntity = ownedEntity;
            UserId = ownedEntity.UserOwnedEntities.FirstOrDefault().UserId;
        }

        #region Backing Fields
        private string _url;
        private OwnedEntity _ownedEntity;
        private int _ownedEntityId;
        private User _user;
        private int _userId;

        #endregion

        public int Id { get; set; }

        [Required]
        public string Url {
            get { return _url; }
            set { _url = ChangeTracker.Set(this, Url, value); }
        }

        public int UserId {
            get { return _userId; }
            set { _userId = ChangeTracker.Set(this, UserId, value); }
        }

        [ForeignKey("UserId")]
        public User User {
            get { return _user; }
            set { _user = ChangeTracker.Set(this, User, value); }
        }

        public int OwnedEntityId {
            get { return _ownedEntityId; }
            set { _ownedEntityId = ChangeTracker.Set(this, OwnedEntityId, value); }
        }

        [ForeignKey("OwnedEntityId")]
        public virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }
    }
}