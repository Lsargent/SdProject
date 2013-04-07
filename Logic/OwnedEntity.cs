using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Logic.Helpers;

namespace Logic {
    public class OwnedEntity : IObjectState, IEquatable<OwnedEntity> {
        
        public OwnedEntity(){}

        public OwnedEntity(User user, ViewPolicy viewPolicy, OwnedEntityChange ownedEntityChange) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            OwnedHistory = new List<OwnedEntityChange>();
            Owners = new List<User>();
            ViewPolicy = viewPolicy;
            AddEntityChange(ownedEntityChange);
            AddOwner(user);
        }

        #region Backing Fields
        private ViewPolicy _viewPolicy;
        #endregion

        public int Id { get; set; }

        public virtual ICollection<User> Owners { get; set; }

        public ViewPolicy ViewPolicy {
            get { return _viewPolicy; }
            set {
                if (TrackingEnabled && ObjectState == ObjectState.Unchanged && ViewPolicy != value) {
                    ObjectState = ObjectState.Modified;
                }
                _viewPolicy = value;
            }
        }

        public virtual ICollection<OwnedEntityChange> OwnedHistory { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public void AddEntityChange(OwnedEntityChange change) {
            ChangeTracker.AddToCollection(this, OwnedHistory, change);
        }

        public void AddOwner(User user) {
            ChangeTracker.AddToCollection(this, Owners, user);
            user.AddOwnedEntity(this);
        }

        public bool Equals(OwnedEntity other) {
            return Id == other.Id;
        }
    }

    public enum ViewPolicy { 
        Open,
        Closed,
        Limited
    }
}