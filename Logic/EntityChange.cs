using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Web;
using Logic.Helpers;

namespace Logic {
    public class EntityChange : IObjectState, IEquatable<EntityChange> {
        
        public EntityChange() {}

        public EntityChange(HttpRequestBase request) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            EditedBy = request.UserHostName;
            IpAddress = request.UserHostAddress;
            UserAgent = request.UserAgent;
            EditedOn = DateTime.Now;        
        }

        #region Backing Fields
        private string _editedBy;
        private string _ipAddress;
        private string _userAgent;
        private DateTime _editedOn;
        private Entity _entity;
        #endregion

        [Key]
        public int Id { get; set; }

        [Required]
        public string EditedBy {
            get { return _editedBy; }
            set { _editedBy = ChangeTracker.Set(this, EditedBy, value); }
        }

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

        [Required]
        public virtual Entity Entity {
            get { return _entity; }
            set { _entity = ChangeTracker.Set(this, Entity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }


        public bool Equals(EntityChange other) {
            return Id == other.Id;
        }
    }
}