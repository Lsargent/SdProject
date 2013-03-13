﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class OwnedEntity : IObjectState {
        public OwnedEntity(){}

        public OwnedEntity(User user, OwnedEntityChange ownedEntityChange) {
            OwnedHistory = new List<OwnedEntityChange>();
            Owners = new List<User>();
            AddEntityChange(ownedEntityChange);
            AddOwner(user);
            ObjectState = ObjectState.Added;
        }

        public int Id { get; set; }

        public virtual List<User> Owners { get; set; }

        public virtual ViewPolicy ViewPolicy { get; set; }

        public virtual List<OwnedEntityChange> OwnedHistory { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public void AddEntityChange(OwnedEntityChange change) {
            OwnedHistory.Add(change);
        }

        public void AddOwner(User user) {
            Owners.Add(user);
        }
    }
}