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
            OwnedEntity = ownedEntity;         
        }

        #region Backing Fields
        private string _url;
        private OwnedEntity _ownedEntity;
        #endregion

        public int Id { get; set; }

        [Required]
        public string Url {
            get { return _url; }
            set { _url = ChangeTracker.Set(this, Url, value); }
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
    }
}