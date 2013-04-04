using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class OwnedEntity : IObjectState {
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

        public int Id { get; set; }

        public virtual ICollection<User> Owners { get; set; }

        public ViewPolicy ViewPolicy { get; set; }

        public virtual ICollection<OwnedEntityChange> OwnedHistory { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public void AddEntityChange(OwnedEntityChange change) {

            OwnedHistory.Add(change);
        }

        public void AddOwner(User user) {
            Owners.Add(user);
        }
    }

    public enum ViewPolicy { 
        Open,
        Closed,
        Limited
    }
}